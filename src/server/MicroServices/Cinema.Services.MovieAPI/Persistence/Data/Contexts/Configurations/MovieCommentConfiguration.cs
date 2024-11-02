using Cinema.Services.MovieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.MovieAPI.Persistence.Data.Contexts.Configurations
{
    public class MovieCommentConfiguration : IEntityTypeConfiguration<MovieComment>
    {
        public void Configure(EntityTypeBuilder<MovieComment> builder)
        {
            builder.HasData(SeedDatas());
        }

        private IEnumerable<MovieComment> SeedDatas()
        {
            yield return new MovieComment()
            {
                Id = 1,
                CreatedDate = new DateTime(2024,11,2),
                Comment = "Film harikaydı, kesinlikle tavsiye ederim! Oyunculuk ve hikaye akışı çok iyiydi.",
                LikeCount = 5,
                MovieId = 8,
                UserId = 1,
                UserName = "tahapek5454"
            };
            yield return new MovieComment()
            {
                Id = 2,
                CreatedDate = new DateTime(2024, 11, 2),
                Comment = "Sürükleyici bir yapım, bir an bile sıkılmadan izledim. Finali de etkileyiciydi!",
                LikeCount = 1,
                MovieId = 8,
                UserId = 2,
                UserName = "deren16"
            };
            yield return new MovieComment()
            {
                Id = 3,
                CreatedDate = new DateTime(2024, 11, 2),
                Comment = "Beklentilerimin çok üzerinde çıktı. Görsel efektler ve atmosfer çok başarılıydı.",
                LikeCount = 1,
                MovieId =8,
                UserId = 3,
                UserName = "mrtGlr06"
            };
            yield return new MovieComment()
            {
                Id = 4,
                CreatedDate = new DateTime(2024, 11, 2),
                Comment = "Senaryo oldukça derindi, düşündürücü bir film olmuş. Özellikle karakter gelişimleri etkileyiciydi.",
                LikeCount = 1,
                MovieId = 8,
                UserId = 4,
                UserName = "g.kaya34"
            };


            yield return new MovieComment()
            {
                Id = 5,
                CreatedDate = new DateTime(2024, 11, 2),
                Comment = "Film boyunca heyecan hiç azalmadı. Aksiyon ve dram dengesi mükemmeldi!",
                LikeCount = 1,
                MovieId = 9,
                UserId = 1,
                UserName = "tahapek5454"
            };
            yield return new MovieComment()
            {
                Id = 6,
                CreatedDate = new DateTime(2024, 11, 2),
                Comment = "Kesinlikle size katılıyorum yorumlarınız harika 🤩",
                LikeCount = 1,
                MovieId = 9,
                UserId = 2,
                UserName = "deren16",
                ParenId = 5
            };
            yield return new MovieComment()
            {
                Id = 7,
                CreatedDate = new DateTime(2024, 11, 2),
                Comment = "Hikayesi çok özgündü ve duygusal yönü oldukça güçlüydü. İzlerken çok etkilendim.",
                LikeCount = 1,
                MovieId = 9,
                UserId = 3,
                UserName = "mrtGlr06"
            };
            yield return new MovieComment()
            {
                Id = 8,
                CreatedDate = new DateTime(2024, 11, 2),
                Comment = "Filmdeki müzikler ve sinematografi çok başarılıydı. Gerçekten izlenmeye değer bir yapım.",
                LikeCount = 1,
                MovieId = 9,
                UserId = 4,
                UserName = "g.kaya34"
            };
        }
    }
}
