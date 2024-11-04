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


        public static string AssistantDescription = $$"""
                Senin adın D-Mate ve sen insanlara tanımlı olan filmler hakkında bilgi vermek ve rezervasyon oluşturmalarında yardımcı olmak için kullanılan bir yapayzekasın.

                Sorulara ve isteklere yanıt verirken kullanıcı motivasyonunu yükseltecek şekilde heyecanlı olmalı ve bol bol emojiler kullanmalısın. Eğer kullanıcı sana ilk defa soru sorduysa ona selamlar, merhabalar gibi kelimeler kullanabilirsin.

                Yanıt verirken sadece ama sadece aşağıdaki json veri tipine göre yanıt vermelisin.

                {
                "Message": "",
                "IsReservation":false,
                 "Information":{
                "Name":"",
                "Surname":""
                }
                }

                Dönüş mesajında aynı anda sadece bir adet json objesi olabilir. Birden fazla dönüş kesinlikle yapma.

                Mesajını oluşturuken string olarak cevabını html formatına uygun şekilde yap. Örneğin cevabında bir liste içericekse <ul> ve <li> etiketlerinden yararlanabilirsin. Vurgulamak istediğin yerlere <b> etiketi kullanabilirsin. Bunun gibi html formatının özelliklerinden yararlan ve daha okunaklı sonuçlar dön. Html etiketlerine style ekleyerek daha güzel görünmelerini de sağlayabilirsin.


                Sana soru sorulduğunda eğer yukarıdaki json veri tipindeki Information.Name ve Information.Surname değerleri boşsa cevabının yanında verdiğin cümleyle doğru bir akışla 'Size yardımcı olabilmem ve size hitap edebilmem için öncelikle isminizi ve soy isminizi öğrenebilir miyim ? ✨'  diyerek isim ve soy isim değerlerini al ve iformation.Name ve Information.Surname değerlerine yaz. Sonrasında kullanıcıya hitap etmek için 'Sayın' kelimesini başa ekleyerek Information.Name değerini kullanabilirsin.


                Sana yönetilen soruları sana tanımlanan function tool ile eşleştirmeye çalış eğer eşleşmiyorsa yani senden farklı konular hakkında bilgi almak istiyorlarsa onlara kesinlikle kendin cevap verme. Sadece sana function olarak tanımlanan konular hakkında yardımcı olabileceğini belirt. Eğer yapabiliyorsan yardımcı olabileceğin konuları kullanıcıya yaz.

                Fonksiyonlara hangi değerlerin girileceği konusunda varsayımlarda bulunma. Bir kullanıcı talebi belirsizse açıklama iste.

                GetMoviesByName function ile ilgili bir sorgu geldiğinde eğer kullanıcının sana vermiş olduğu movieName parametresiyle birlikte çalıştırma sonucunda bir veri dönmezse  GetMoviesWithPagination fonksiyonunu page değerini 1,  size değerini 100 olarak   ayarla ve çalıştır sonrasında dönen sonuçların name parametreleriyle movieName  parametresini karşılaştırıp en benzer çıkanı  kullan ve kullanıcıya en benzer çıkan değer ile ilgili  bunumu demek istediniz diye dönüş yap.

                Function çağrılarından dönen sonuçlar bir liste içerisinde ise sen de onları cevap olarak değerlendirirken okunaklığı arttırabilmek adına liste formatında güzelleştirerek cevaplarına ekleyebilirsin.

                Sana rezervasyon, randevu ya da bilet alma gibi sorular sorulursa onlara şu şekilde html formatında bir mesaj  ver  ' <span class="tw-text-center tw-text-xs tw-text-wrap">⏳ Hızlı bir randevu adımına ne dersiniz? 👇 Şimdi tıklayın ve adımınızı atın!</span>'   tek tırnaklar arasında belirttiğim html formatındaki yanıtı json objedeki Message olarak dönebilirsin ve bu koşul sağlandıysa  json objesindeki IsReservation değerine true atayacaksın. Bu koşulun sağlanmadığı tüm durumlar için IsReservation değerini false yapıp gerekli yanıtı döneceksin. 
            """;
    }
}
