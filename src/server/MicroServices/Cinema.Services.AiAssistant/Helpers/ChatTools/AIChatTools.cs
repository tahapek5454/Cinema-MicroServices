using Cinema.Services.AiAssistant.Services.Concrete;
using OpenAI.Assistants;
using OpenAI.Chat;

namespace Cinema.Services.AiAssistant.Helpers.ChatTools
{
#pragma warning disable OPENAI001
    public static class AIChatTools
    {
        public static readonly ChatTool getCurrentLocationTool = ChatTool.CreateFunctionTool(
                                                                                                functionName: nameof(HelperMethods.GetCurrentLocation),
                                                                                                functionDescription: "Kullanıcının geçerli konumunu alır."
                                                                                              );

        public static readonly ChatTool getCurrentWeatherTool = ChatTool.CreateFunctionTool(
                                                                                                functionName: nameof(HelperMethods.GetCurrentWeather),
                                                                                                functionDescription: "Belirli bir konumdaki mevcut hava durumunu alır.",
                                                                                                functionParameters: BinaryData.FromBytes("""
                                                                                                                                            {
                                                                                                                                                "type": "object",
                                                                                                                                                "properties": {
                                                                                                                                                    "location": {
                                                                                                                                                        "type": "string",
                                                                                                                                                        "description": "Şehir ve eyalet, örneğin Boston, MA."
                                                                                                                                                    },
                                                                                                                                                    "unit": {
                                                                                                                                                        "type": "string",
                                                                                                                                                        "enum": [ "celsius", "fahrenheit" ],
                                                                                                                                                        "description": "Kullanılacak sıcaklık birimi. Bunu belirtilen konumdan çıkar."
                                                                                                                                                    }
                                                                                                                                                },
                                                                                                                                                "required": [ "location" ]
                                                                                                                                            }
                                                                                                                                            """u8.ToArray())
                                                                                            );



        public static FunctionToolDefinition getLocationTool = new()
        {
            FunctionName = nameof(HelperMethods.GetCurrentLocation),
            Description = "Kullanıcının geçerli konumunu cevap olarak döner."
        };

        public static FunctionToolDefinition getHighestRatedMovieTool = new()
        {
            FunctionName = nameof(AppService.GetHighestRatedMovie),
            Description = "En yüksek, en çok puana sahip olan filmi döner. Bunu filmlerin en iyisi, en güzeli, en çok puan alanı gibi benzer sorular sorulduğunda çağırabilirsin. Örneğin 'En yüksek puana sahip olan film hangisi'."
        };

        public static FunctionToolDefinition getMoviesWithPaginationTool = new()
        {
            FunctionName = nameof(AppService.GetMoviesWithPagination),
            Description = "Sistemdeki filmleri parametrelerde belirtilen miktarda getirir. Sayfalama mantığını kullanır. Bunu filmlerin listelemek, görüntülemek istediği zaman çağırabilirsin. page ve size parametreleri zorunlu değildir. Örneğin : 'Bana filmleri getirebilir misin ?' sorusuna karşılık çağırabilirsin.",
            Parameters = BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "page": {
                        "type": "number",
                        "description": "Sayfalama mantığındaki sayıya denk gelir."
                    },
                    "size": {
                        "type": "number",                   
                        "description": "Listelenecek verinin sayısını belirtir."
                    }
                }
            }
            """),
        };

        public static FunctionToolDefinition getMoviesByNameTool = new()
        {
            FunctionName = nameof(AppService.GetMoviesByName),
            Description = "Parametre olarak ismi verilen filmin bilgilerini döner. Bunu sana belirli isimlerdeki filmler hakkında bilgi almak istediklerinde, ilgili filmin varlığını kontrol etmek istediklerinde, ilgili filmin bilgilerini elde etmek için kullanabilirsin. Örneğin 'Garfield filmi hakkında bilgi verebilir misin?' sorusuna karşılık çağırabilirsin.",
            Parameters = BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "movieName": {
                        "type": "string",
                        "description": "Seçilen filmin ismini belirtir."
                    }
                },
                "required": [ "movieName" ]
            }
            """),
        };

        public static FunctionToolDefinition getWeatherTool = new()
        {
            FunctionName = nameof(HelperMethods.GetCurrentWeather),
            Description = "Belirli bir konumdaki mevcut hava durumunu cevap olarak döner.",
            Parameters = BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "location": {
                        "type": "string",
                        "description": "Şehir ve eyalet, örneğin Boston, MA."
                    },
                    "unit": {
                        "type": "string",
                        "enum": [ "celsius", "fahrenheit" ],
                        "description": "Kullanılacak sıcaklık birimi. Bunu belirtilen konumdan çıkar"
                    }
                },
                "required": [ "location" ]
            }
            """),
        };

    }
}
