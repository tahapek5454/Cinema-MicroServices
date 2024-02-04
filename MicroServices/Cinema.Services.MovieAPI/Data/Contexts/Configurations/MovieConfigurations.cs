using Cinema.Services.MovieAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.MovieAPI.Data.Contexts.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(GetSeedDatas());
     
        }
        private IEnumerable<Movie> GetSeedDatas()
        {

            yield return new Movie()
            {
                Id = 1,
                Name = "Lohusa",
                Name_EN = "Lohusa",
                Description = "Çocuklarının doğumundan sonraki ilk 40 günde yeni hayatlarına uyum sağlamaya çalışan bir anne ve babanın eğlenceli hikayesini konu alıyor.",
                Description_EN = "It tells the entertaining story of a mother and father trying to adapt to their new lives in the first 40 days after the birth of their children.",
                Point = 7.4,
                CreatedDate = new DateTime(2024,2,5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.58,
            };

            yield return new Movie()
            {
                Id = 2,
                Name = "Efsane",
                Name_EN = "Legend",
                Description = $"Çorum'da yaşayan Sadık (Ahmet Kural) ve ailesi, binlerce yıllık aile geleneğini devam ettirerek yoğurtçuluk yaparlar.<br/> Yoğurtları lezzeti ve şifası ile bilinir.<br/> Bu dillere destan yoğurdun sırrını ise ailenin en büyüğü olan Dede saklar ve yoğurtları...",
                Description_EN = "Sadık (Ahmet Kural) and his family, living in Çorum, continue the age-old family tradition by engaging in yogurt production.<br/> Their yogurt is known for its delicious taste and healing properties.<br/> The secret of this legendary yogurt is guarded by the family's eldest, Dede, and the yogurts...",
                Point = 5.2,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.45,
            };

            yield return new Movie()
            {
                Id = 3,
                Name = "Rafadan Tayfa 4: Hayrimatör",
                Name_EN = "Rafadan Tayfa 4: Hayrimatör",
                Description = "Hayri, uzaya çıkan en genç insan olarak ün kazanıp üstün zekâlı öğrencilerin girdiği bir bilim teknik okuluna kabul alır.<br/> Artık mahallesinde çok az vakit geçirip çoğunlukla Yüz Yılın İcadı olarak hitap ettiği dev robot Hayrimatör üzerine çalışır...",
                Description_EN = "Hayri gains fame as the youngest person to go to space and gets admitted to a science and technology school for exceptionally intelligent students.<br/> Now, spending very little time in his neighborhood, he mostly works on the giant robot he refers to as The Invention of the Century, which he calls Hayrimator...",
                Point = 8.1,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.32,
            };

            yield return new Movie()
            {
                Id = 4,
                Name = "Kolpaçino 4 4'lük",
                Name_EN = "Kolpaçino 4 4'lük",
                Description = "Kolpaçino serisinin 3. filmi Kolpaçino 3. Devre'den sonra Kolpaçino 4 4'lük seyirci ile buluşmaya hazırlanıyor.<br/> Aralarındaki düşmanlığa son vermek ve hesaplaşmak isteyen Özgür ve Sabri, bir mekanda toplanırlar.<br/> Tayfun'un nişanından önce son ...",
                Description_EN = "Following the third film in the Kolpaçino series, Kolpaçino 3. Devre, Kolpaçino 4 is getting ready to meet the audience with a score of 4 out of 4.<br/> Özgür and Sabri, who want to put an end to their enmity and settle the score, gather at a venue. Just before Tayfun's engagement, they aim to finalize their long-lasting rivalry...",
                Point = 4.6,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.3,
            };

            yield return new Movie()
            {
                Id = 5,
                Name = "Cem Karaca'nın Gözyaşları",
                Name_EN = "Cem Karaca'nın Gözyaşları",
                Description = "Film, Cem Karaca'nın (İsmail Hacıoğlu) büyük başarılarından aşklarına; sürgünlerden, kayıplarına ve kavuşmalarına hayatını bütün iniş çıkışlarıyla gözler önüne seriyor.",
                Description_EN = "The movie unfolds the life of Cem Karaca (played by İsmail Hacıoğlu), showcasing his significant achievements, love affairs, exiles, losses, and reunions with all the ups and downs.",
                Point = 9,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 2.03,
            };

            yield return new Movie()
            {
                Id = 6,
                Name = "Kardeş Takımı",
                Name_EN = "Brother Team",
                Description = "4 kardeş Deniz, Derya, Ali ve Yaz'ın sıradan hayatları, anne ve babalarının aslında birer gizli ajanlar olduklarını öğrenmeli ile bir anda değişir.<br/> Olağanüstü teknolojilerin bünyesinde korunduğu TeknoStar için çalışan anne ve babaları, bu teknoloj...",
                Description_EN = "The ordinary lives of four siblings, Deniz, Derya, Ali, and Yaz, take a sudden turn when they discover that their parents are actually secret agents.<br/> Their parents work for TeknoStar, where extraordinary technologies are protected.<br/> The siblings find themselves caught up in a world of espionage, adventure, and high-tech intrigue as they navigate the challenges and mysteries that come with their parents' double lives.",
                Point = 7.5,
                CreatedDate = new DateTime(2024, 2, 5),
                UpdatedDate = new DateTime(2024, 2, 5),
                Time = 1.35,
            };
        }
    }
}
