using Cinema.Services.CategoryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.CategoryAPI.Persistence.Data.Contexts.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedDatas());
        }

        private IEnumerable<Category> SeedDatas()
        {
            yield return new Category()
            {
                Id = 1,
                Name = "Komedi",
                Name_EN = "Comedy",
                CreatedDate = new DateTime(2024, 2, 5),
            };

            yield return new Category()
            {
                Id = 2,
                Name = "Animasyon",
                Name_EN = "Animation",
                CreatedDate = new DateTime(2024, 2, 5),
            };

            yield return new Category()
            {
                Id = 3,
                Name = "Biyografik",
                Name_EN = "Biographical",
                CreatedDate = new DateTime(2024, 2, 5),
            };
        }
    }
}
