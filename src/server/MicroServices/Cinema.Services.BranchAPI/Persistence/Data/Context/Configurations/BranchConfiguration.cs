using Cinema.Services.BranchAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.BranchAPI.Persistence.Data.Context.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasData(SeedDatas());
        }

        private IEnumerable<Branch> SeedDatas()
        {
            DateTime defaultDate = new DateTime(2024, 2, 5);
            yield return new Branch()
            {
                Id = 1,
                Address = "Arabacıalanı, 54050 Serdivan/Sakarya",
                Address_EN = "Arabacıalanı, 54050 Serdivan/Sakarya English",
                CreatedDate = defaultDate,
                Description = "Serdivan AVM'de Paribu Cineverse İle Kesintisiz Film Keyfi",
                Description_EN = "Uninterrupted Movie Pleasure with Cinema Maxiums at Serdivan Shopping Mall",
                DistrictId = 14,
                UpdatedDate = defaultDate,
                Name = "Serdivan Paribu Cineverse",
            };
        }
    }
}
