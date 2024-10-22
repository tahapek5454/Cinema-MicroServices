using Cinema.Services.AiAssistant.Helpers;
using Cinema.Services.AiAssistant.Helpers.ChatTools;
using Cinema.Services.AiAssistant.Models;
using Cinema.Services.AiAssistant.Services.Abstract;
using OpenAI.Assistants;
using OpenAI.Chat;
using SharedLibrary.Models.SharedModels.Movies;
using System.ClientModel;
using System.Text;
using System.Text.Json;

namespace Cinema.Services.AiAssistant.Services.Concrete
{
#pragma warning disable OPENAI001
    public class AiService : IAiService
    {

        private readonly ChatClient _client;
        private readonly AssistantClient _assistantClient;
        private readonly List<ChatMessage> _messages; // history
        private readonly string _assistanId;
        private readonly IAppService _appService;


        //Fonksiyonlara hangi değerlerin girileceği konusunda varsayımlarda bulunma.Bir kullanıcı talebi belirsizse açıklama iste.

        public AiService(IConfiguration configuration
                                        , IAppService appService)
        {
            _client = new(model: "gpt-4o", apiKey: configuration["OpenAI:key"]);
            _assistanId = configuration["OpenAI:assistant"];
            _assistantClient = new(apiKey: configuration["OpenAI:key"]);
            _messages = new List<ChatMessage>();
            _appService = appService;
        }


        public string HealthCheck()
        {
            ChatCompletion completion = _client.CompleteChat("Benim mesajıma görebiliyorsan burdayım ve sağlıklıyım diyebilirsin.");

            return $"[ASSISTANT]: {completion.Content[0].Text}";
        }
        public string FunctionCallTest(string content)
        {
            // List<ChatMessage> _messages = [new UserChatMessage(content)];
            _messages.Add(new UserChatMessage(content));

            ChatCompletionOptions options = new()
            {
                Tools = { AIChatTools.getCurrentLocationTool, AIChatTools.getCurrentWeatherTool },
            };



            bool requiresAction = false;

            StringBuilder stringBuilder = new StringBuilder();

            do
            {
                requiresAction = false;
                ChatCompletion completion = _client.CompleteChat(_messages, options);

                switch (completion.FinishReason)
                {
                    case ChatFinishReason.Stop:
                        {
                            _messages.Add(new AssistantChatMessage(completion));
                            break;
                        }

                    case ChatFinishReason.Length:
                        {
                            throw new NotImplementedException("MaxTokens parametresi veya token limitinin aşılması nedeniyle tamamlanmamış model çıktısı.");
                        }

                    case ChatFinishReason.ContentFilter:
                        {
                            throw new NotImplementedException("Bir içerik filtresi bayrağı nedeniyle atlanmış içerik.");
                        }
                    case ChatFinishReason.ToolCalls:
                        {
                            _messages.Add(new AssistantChatMessage(completion)); // bos bir mesaj atti neden
                            foreach (ChatToolCall toolCall in completion.ToolCalls)
                            {
                                switch (toolCall.FunctionName)
                                {
                                    case nameof(HelperMethods.GetCurrentLocation):
                                        {
                                            string toolResult = HelperMethods.GetCurrentLocation();
                                            _messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
                                            break;
                                        }


                                    case nameof(HelperMethods.GetCurrentWeather):
                                        {
                                            using JsonDocument argumentsJson = JsonDocument.Parse(toolCall.FunctionArguments);
                                            bool hasLocation = argumentsJson.RootElement.TryGetProperty("location", out JsonElement location);
                                            bool hasUnit = argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unit);

                                            if (!hasLocation)
                                            {
                                                throw new ArgumentNullException(nameof(location), "Konum Bilgisi Zorunludur.");
                                            }

                                            string toolResult = hasUnit ? HelperMethods.GetCurrentWeather(location.GetString(), unit.GetString()) : HelperMethods.GetCurrentWeather(location.GetString());

                                            _messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
                                            break;
                                        }



                                    default:
                                        {
                                            throw new NotImplementedException();

                                        }

                                }
                            }

                            requiresAction = true;

                            break;
                        }
                    case ChatFinishReason.FunctionCall:
                        {
                            throw new NotImplementedException("Araç çağrıları lehine kullanımdan kaldırılmıştır.");
                        }
                    default:
                        {
                            throw new NotImplementedException(completion.FinishReason.ToString());
                        }
                }


                foreach (var item in completion.Content)
                {
                    stringBuilder.AppendLine(item.Text);
                }

            } while (requiresAction);


            return stringBuilder.ToString();
        }
        public async Task<string> AssistantTest(string content)
        {

            //AssistantCreationOptions assistantOptions = new()
            //{
            //    Name = "Taha Asistan Test",
            //    Instructions = "Fonksiyonlara hangi değerlerin girileceği konusunda varsayımlarda bulunma. Bir kullanıcı talebi belirsizse açıklama iste.",
            //    Tools = { AIChatTools.getLocationTool, AIChatTools.getWeatherTool },
            //};

            //// create once after that can be get
            //Assistant assistant = _assistantClient.CreateAssistant("gpt-4-turbo", assistantOptions);

            Assistant assistant = await _assistantClient.GetAssistantAsync(_assistanId);

            ThreadCreationOptions threadOptions = new()
            {
                InitialMessages = { content }
            };

            ThreadRun run = _assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);



            while (!run.Status.IsTerminal)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                run = _assistantClient.GetRun(run.ThreadId, run.Id);

                // If the run requires action, resolve them.
                if (run.Status == RunStatus.RequiresAction)
                {
                    List<ToolOutput> toolOutputs = [];

                    foreach (RequiredAction action in run.RequiredActions)
                    {
                        switch (action.FunctionName)
                        {
                            case nameof(HelperMethods.GetCurrentLocation):
                                {
                                    string toolResult = HelperMethods.GetCurrentLocation();
                                    toolOutputs.Add(new ToolOutput(action.ToolCallId, toolResult));
                                    break;
                                }

                            case nameof(HelperMethods.GetCurrentWeather):
                                {
                                    // The arguments that the model wants to use to call the function are specified as a
                                    // stringified JSON object based on the schema defined in the tool definition. Note that
                                    // the model may hallucinate arguments too. Consequently, it is important to do the
                                    // appropriate parsing and validation before calling the function.
                                    using JsonDocument argumentsJson = JsonDocument.Parse(action.FunctionArguments);
                                    bool hasLocation = argumentsJson.RootElement.TryGetProperty("location", out JsonElement location);
                                    bool hasUnit = argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unit);

                                    if (!hasLocation)
                                    {
                                        throw new ArgumentNullException(nameof(location), "Konum girmek zorunludur.");
                                    }

                                    string toolResult = hasUnit
                                        ? HelperMethods.GetCurrentWeather(location.GetString(), unit.GetString())
                                        : HelperMethods.GetCurrentWeather(location.GetString());
                                    toolOutputs.Add(new ToolOutput(action.ToolCallId, toolResult));
                                    break;
                                }

                            default:
                                {
                                    // Handle other or unexpected calls.
                                    throw new NotImplementedException();
                                }
                        }
                    }

                    // Submit the tool outputs to the assistant, which returns the run to the queued state.
                    run = _assistantClient.SubmitToolOutputsToRun(run.ThreadId, run.Id, toolOutputs);
                }
            }




            StringBuilder stringBuilder = new StringBuilder();
            if (run.Status == RunStatus.Completed)
            {
                AsyncCollectionResult<ThreadMessage> messages
                    = _assistantClient.GetMessagesAsync(run.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

                await foreach (ThreadMessage message in messages)
                {
                    Console.WriteLine($"[{message.Role.ToString().ToUpper()}]: ");
                    foreach (MessageContent contentItem in message.Content)
                    {
                        Console.WriteLine($"{contentItem.Text}");
                        if (message.Role == MessageRole.Assistant)
                            stringBuilder.AppendLine(contentItem.Text);

                        if (contentItem.ImageFileId is not null)
                        {
                            Console.WriteLine($" <Image File ID> {contentItem.ImageFileId}");
                        }

                        // Include annotations, if any.
                        if (contentItem.TextAnnotations.Count > 0)
                        {
                            Console.WriteLine();
                            foreach (TextAnnotation annotation in contentItem.TextAnnotations)
                            {
                                Console.WriteLine($"* File ID used by file_search: {annotation.InputFileId}");
                                Console.WriteLine($"* File ID created by code_interpreter: {annotation.OutputFileId}");
                                Console.WriteLine($"* Text to replace: {annotation.TextToReplace}");
                                Console.WriteLine($"* Message content index range: {annotation.StartIndex}-{annotation.EndIndex}");
                            }
                        }

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                throw new NotImplementedException(run.Status.ToString());
            }








            return stringBuilder.ToString();
        }
        public async Task<AssistantResponse> MovieAssistant(string content, string? threadId)
        {
            #region CreateAssistant
            //AssistantCreationOptions assistantOptions = new()
            //{
            //    Name = "D-TIX Assistant",
            //    Instructions = "Fonksiyonlara hangi değerlerin girileceği konusunda varsayımlarda bulunma. Bir kullanıcı talebi belirsizse açıklama iste.",
            //    Tools = { AIChatTools.getHighestRatedMovieTool, AIChatTools.getMoviesWithPaginationTool },
            //};

            ////// create once after that can be get
            //Assistant assistant = _assistantClient.CreateAssistant("gpt-4-turbo", assistantOptions);
            #endregion

            Assistant assistant = await _assistantClient.GetAssistantAsync(_assistanId);

            AssistantThread thread = null;

            if (string.IsNullOrEmpty(threadId))
            {
                thread = await CreateThreadAsync();
            }
            else
            {
                thread = await GetTharedAsync(threadId);
            }

            if (thread == null)
                throw new Exception("Thread Bulunamadı ya da Oluşturulmadı.");

            await _assistantClient.CreateMessageAsync(thread.Id, MessageRole.User, [content]);

            ThreadCreationOptions threadOptions = new()
            {
                InitialMessages = { content }
            };

            ThreadRun run = await _assistantClient.CreateRunAsync(thread.Id, assistant.Id);

            while (!run.Status.IsTerminal)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                run = _assistantClient.GetRun(run.ThreadId, run.Id);

                // If the run requires action, resolve them.
                if (run.Status == RunStatus.RequiresAction)
                {
                    List<ToolOutput> toolOutputs = [];

                    foreach (RequiredAction action in run.RequiredActions)
                    {
                        switch (action.FunctionName)
                        {
                            case nameof(AppService.GetHighestRatedMovie):
                                {
                                    var toolResult = await _appService.GetHighestRatedMovie();
                                    if(toolResult == null)
                                        toolOutputs.Add(new ToolOutput(action.ToolCallId, "Sistemimizde uygun film bulunmamaktadır."));
                                    else
                                        toolOutputs.Add(new ToolOutput(action.ToolCallId, JsonSerializer.Serialize(toolResult)));
                                    break;
                                }

                            case nameof(AppService.GetMoviesWithPagination):
                                {
                                    using JsonDocument argumentsJson = JsonDocument.Parse(action.FunctionArguments);
                                    bool hasPage = argumentsJson.RootElement.TryGetProperty("page", out JsonElement page);
                                    bool hasSize = argumentsJson.RootElement.TryGetProperty("size", out JsonElement size);
                                    List<MovieSharedVM> result = new List<MovieSharedVM>();

                                    if (hasSize && hasSize)
                                        result = await _appService.GetMoviesWithPagination(page: int.Parse(page.GetRawText()), size: int.Parse(size.GetRawText()));
                                    else
                                        result = await _appService.GetMoviesWithPagination();

                                    toolOutputs.Add(new ToolOutput(action.ToolCallId, JsonSerializer.Serialize(result)));
                                    break;
                                }

                            default:
                                {
                                    // Handle other or unexpected calls.
                                    throw new NotImplementedException();
                                }
                        }
                    }

                    // Submit the tool outputs to the assistant, which returns the run to the queued state.
                    run = _assistantClient.SubmitToolOutputsToRun(run.ThreadId, run.Id, toolOutputs);
                }
            }



            Stack<string> responses = new();
            if (run.Status == RunStatus.Completed)
            {
                AsyncCollectionResult<ThreadMessage> messages
                    = _assistantClient.GetMessagesAsync(run.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

                await foreach (ThreadMessage message in messages)
                {
                    Console.WriteLine($"[{message.Role.ToString().ToUpper()}]: ");
                    foreach (MessageContent contentItem in message.Content)
                    {
                        Console.WriteLine($"{contentItem.Text}");
                        if (message.Role == MessageRole.Assistant)
                            responses.Push(contentItem.Text);
                

                        if (contentItem.ImageFileId is not null)
                        {
                            Console.WriteLine($" <Image File ID> {contentItem.ImageFileId}");
                        }

                        // Include annotations, if any.
                        if (contentItem.TextAnnotations.Count > 0)
                        {
                            Console.WriteLine();
                            foreach (TextAnnotation annotation in contentItem.TextAnnotations)
                            {
                                Console.WriteLine($"* File ID used by file_search: {annotation.InputFileId}");
                                Console.WriteLine($"* File ID created by code_interpreter: {annotation.OutputFileId}");
                                Console.WriteLine($"* Text to replace: {annotation.TextToReplace}");
                                Console.WriteLine($"* Message content index range: {annotation.StartIndex}-{annotation.EndIndex}");
                            }
                        }

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                throw new NotImplementedException(run.Status.ToString());
            }

            return new() { Response=responses.Any() ? responses.Pop() : string.Empty, ThreadId = thread.Id };
        }

        private async Task<AssistantThread> CreateThreadAsync()
            => await _assistantClient.CreateThreadAsync();

        private async Task<AssistantThread> GetTharedAsync(string threadId)
            => await _assistantClient.GetThreadAsync(threadId);



    }
}
