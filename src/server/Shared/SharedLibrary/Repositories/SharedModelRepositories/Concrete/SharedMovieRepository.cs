using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SharedLibrary.Models.SharedModels.Comments;
using SharedLibrary.Models.SharedModels.Movies;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace SharedLibrary.Repositories.SharedModelRepositories.Concrete
{
    public class SharedMovieRepository : SharedBaseRepository<MovieSharedVM>, ISharedMovieRepository
    {
        public SharedMovieRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }

        public async Task AddSeedDatas()
        {
            var movieCount = this.Query().Count();

            if (movieCount == 0)
            {
                foreach (var item in SeedDatas())
                {
                    await this.AddAsync(item);
                }
           
            }
        }


        private IEnumerable<MovieSharedVM> SeedDatas()
        {
            yield return new MovieSharedVM()
            {
                Id = 1,
                Name = "Lohusa",
                Description = "Çocuklarının doğumundan sonraki ilk 40 günde yeni hayatlarına uyum sağlamaya çalışan bir anne ve babanın eğlenceli hikayesini konu alıyor.",
                Point = 7.4,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.58,
                CategoryId = 1, // Komedi,
                Category = new()
                {
                    Id = 1,
                    Name = "Komedi"
                }
            };

            yield return new MovieSharedVM()
            {
                Id = 2,
                Name = "Efsane",
                Description = $"Çorum'da yaşayan Sadık (Ahmet Kural) ve ailesi, binlerce yıllık aile geleneğini devam ettirerek yoğurtçuluk yaparlar.<br/> Yoğurtları lezzeti ve şifası ile bilinir.<br/> Bu dillere destan yoğurdun sırrını ise ailenin en büyüğü olan Dede saklar ve yoğurtları...",
                Point = 5.2,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.45,
                CategoryId = 1,
                Category = new()
                {
                    Id = 1,
                    Name = "Komedi"
                }           
            };

            yield return new MovieSharedVM()
            {
                Id = 3,
                Name = "Rafadan Tayfa 4: Hayrimatör",
                Description = "Hayri, uzaya çıkan en genç insan olarak ün kazanıp üstün zekâlı öğrencilerin girdiği bir bilim teknik okuluna kabul alır.<br/> Artık mahallesinde çok az vakit geçirip çoğunlukla Yüz Yılın İcadı olarak hitap ettiği dev robot Hayrimatör üzerine çalışır...",
                Point = 8.1,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.32,
                CategoryId = 2, // Animasyon
                Category = new()
                {
                    Id = 2,
                    Name = "Animasyon"
                }
            };

            yield return new MovieSharedVM()
            {
                Id = 4,
                Name = "Kolpaçino 4 4'lük",
                Description = "Kolpaçino serisinin 3. filmi Kolpaçino 3. Devre'den sonra Kolpaçino 4 4'lük seyirci ile buluşmaya hazırlanıyor.<br/> Aralarındaki düşmanlığa son vermek ve hesaplaşmak isteyen Özgür ve Sabri, bir mekanda toplanırlar.<br/> Tayfun'un nişanından önce son ...",
                Point = 4.6,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.3,
                CategoryId = 1,
                Category = new()
                {
                    Id = 1,
                    Name = "Komedi"
                }

            };

            yield return new MovieSharedVM()
            {
                Id = 5,
                Name = "Cem Karaca'nın Gözyaşları",
                Description = "Film, Cem Karaca'nın (İsmail Hacıoğlu) büyük başarılarından aşklarına; sürgünlerden, kayıplarına ve kavuşmalarına hayatını bütün iniş çıkışlarıyla gözler önüne seriyor.",
                Point = 9,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 2.03,
                CategoryId = 3, // Biyografik
                Category = new()
                {
                    Id = 3,
                    Name = "Biyografik"
                }
            };

            yield return new MovieSharedVM()
            {
                Id = 6,
                Name = "Kardeş Takımı",
                Description = "4 kardeş Deniz, Derya, Ali ve Yaz'ın sıradan hayatları, anne ve babalarının aslında birer gizli ajanlar olduklarını öğrenmeli ile bir anda değişir.<br/> Olağanüstü teknolojilerin bünyesinde korunduğu TeknoStar için çalışan anne ve babaları, bu teknoloj...",
                Point = 7.5,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.35,
                CategoryId = 1,
                Category = new()
                {
                    Id = 1,
                    Name = "Komedi"
                }
            };

            yield return new MovieSharedVM()
            {
                Id = 7,
                Name = "Alien",
                Description = "Bir grup genç uzay kolonizatörü, terk edilmiş bir uzay istasyonunun derinliklerini araştırırken evrendeki en korkunç yaşam formuyla yüz yüze gelir.Bir grup genç uzay kolonizatörü, terk edilmiş bir uzay istasyonunun derinliklerini araştırırken evrendeki en korkunç yaşam formuyla yüz yüze gelir.",
                Point = 7.5,
                CreatedDate = new DateTime(2024, 10, 20),
                UpdatedDate = new DateTime(2024, 10, 20),
                Time = 1.35,
                CategoryId = 4,
                Category = new()
                {
                    Id = 4,
                    Name = "Korku"
                }
            };

            yield return new MovieSharedVM()
            {
                Id = 8,
                Name = "Deadpool & Wolverine",
                Description = "Wolverine yaralarından kurtulmaya çalışırken yolu boşboğaz Deadpool ile kesişir. Ortak bir düşmanı yenmek için takım olurlar.",
                Point = 7.5,
                CreatedDate = new DateTime(2024, 10, 20),
                UpdatedDate = new DateTime(2024, 10, 20),
                Time = 2.07,
                CategoryId = 5,
                Category = new()
                {
                    Id = 5,
                    Name = "Aksiyon"
                },
                MovieComments = new List<MovieCommentSharedVM>()
                {
                    new MovieCommentSharedVM()
                    {
                        Id = 1,
                        CreatedDate = new DateTime(2024,11,2),
                        Comment = "Film harikaydı, kesinlikle tavsiye ederim! Oyunculuk ve hikaye akışı çok iyiydi.",
                        LikeCount = 5,
                        MovieId = 8,
                        UserId = 1,
                        UserName = "tahapek5454",
                        
                    },
                    new MovieCommentSharedVM()
                    {
                        Id = 2,
                        CreatedDate = new DateTime(2024, 11, 2),
                        Comment = "Sürükleyici bir yapım, bir an bile sıkılmadan izledim. Finali de etkileyiciydi!",
                        LikeCount = 1,
                        MovieId = 8,
                        UserId = 2,
                        UserName = "deren16"

                    },
                    new MovieCommentSharedVM()
                    {
                        Id = 3,
                        CreatedDate = new DateTime(2024, 11, 2),
                        Comment = "Beklentilerimin çok üzerinde çıktı. Görsel efektler ve atmosfer çok başarılıydı.",
                        LikeCount = 1,
                        MovieId =8,
                        UserId = 3,
                        UserName = "mrtGlr06"

                    },
                    new MovieCommentSharedVM()
                    {
                        Id = 4,
                        CreatedDate = new DateTime(2024, 11, 2),
                        Comment = "Senaryo oldukça derindi, düşündürücü bir film olmuş. Özellikle karakter gelişimleri etkileyiciydi.",
                        LikeCount = 1,
                        MovieId = 8,
                        UserId = 4,
                        UserName = "g.kaya34"

                    },
                }
            };

            yield return new MovieSharedVM()
            {
                Id = 9,
                Name = "Garfield",
                Description = "Karikatürist Jim Davis tarafından 1978 yılında yaratılan ve hikâyeleri karikatür sayfalarından televizyona kadar uzanan Garfield'ın animasyon filmi, kayıp babası Vic ile yolları yeniden kesişen Garfield'ın, arkadaşı Ollie ile birlikte yaşadığı maceraları konu ediniyor.",
                Point = 7.5,
                CreatedDate = new DateTime(2024, 10, 20),
                UpdatedDate = new DateTime(2024, 10, 20),
                Time = 1.41,
                CategoryId = 2,
                Category = new()
                {
                    Id = 2,
                    Name = "Animasyon"
                },
                MovieComments = new()
                {
                    new()
                    {
                        Id = 5,
                        CreatedDate = new DateTime(2024, 11, 2),
                        Comment = "Film boyunca heyecan hiç azalmadı. Aksiyon ve dram dengesi mükemmeldi!",
                        LikeCount = 1,
                        MovieId = 9,
                        UserId = 1,
                        UserName = "tahapek5454"
                    },
                    new()
                    {
                        Id = 6,
                        CreatedDate = new DateTime(2024, 11, 2),
                        Comment = "Kesinlikle size katılıyorum yorumlarınız harika 🤩",
                        LikeCount = 1,
                        MovieId = 9,
                        UserId = 2,
                        UserName = "deren16",
                        ParenId = 5
                    },
                    new()
                    {
                        Id = 7,
                        CreatedDate = new DateTime(2024, 11, 2),
                        Comment = "Hikayesi çok özgündü ve duygusal yönü oldukça güçlüydü. İzlerken çok etkilendim.",
                        LikeCount = 1,
                        MovieId = 9,
                        UserId = 3,
                        UserName = "mrtGlr06"
                    },
                    new()
                    {
                        Id = 8,
                        CreatedDate = new DateTime(2024, 11, 2),
                        Comment = "Filmdeki müzikler ve sinematografi çok başarılıydı. Gerçekten izlenmeye değer bir yapım.",
                        LikeCount = 1,
                        MovieId = 9,
                        UserId = 4,
                        UserName = "g.kaya34"
                    },
                }
            };

            yield return new MovieSharedVM()
            {
                Id = 10,
                Name = "Ters Yüz 2",
                Description = "Ters Yüz 2, artık bir ergen olan ve çok daha çılgın, kişiselleştirilmiş duygularla uğraşmak zorunda olan Genç Riley'nin maceralarını konu ediyor.",
                Point = 7.5,
                CreatedDate = new DateTime(2024, 10, 20),
                UpdatedDate = new DateTime(2024, 10, 20),
                Time = 1.36,
                CategoryId = 2,
                Category = new()
                {
                    Id = 2,
                    Name = "Animasyon"
                }
            };
        }
    }
}
