using Cinema.Services.AiAssistant.Models;

namespace Cinema.Services.AiAssistant.Services.Abstract
{
    public interface IAiService
    {
        string HealthCheck();

        string FunctionCallTest(string content);
        Task<string> AssistantTest(string content);

        Task<AssistantResponse> MovieAssistant(string content, string? threadId);
        Task<bool> CreateAssistant();
    }
}
