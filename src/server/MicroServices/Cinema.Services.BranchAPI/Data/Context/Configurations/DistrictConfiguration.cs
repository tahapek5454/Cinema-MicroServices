using Cinema.Services.BranchAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.BranchAPI.Data.Context.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasData(SeedDatas());
        }

        private  IEnumerable<District> SeedDatas()
        {
            DateTime defaultDate = new DateTime(2024, 2, 5);
            List<District> districts = new List<District>
            {
                new District { Id = 1, Name = "Adapazarı", CreatedDate = defaultDate, UpdatedDate = defaultDate, CityId = 54 },
                new District { Id = 2, Name = "Akyazı", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 3, Name = "Arifiye", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 4, Name = "Erenler", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 5, Name = "Ferizli", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 6, Name = "Geyve", CreatedDate = defaultDate, UpdatedDate = defaultDate, CityId = 54 },
                new District { Id = 7, Name = "Hendek", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 8, Name = "Karapürçek", CreatedDate = defaultDate, UpdatedDate = defaultDate, CityId = 54},
                new District { Id = 9, Name = "Karasu", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 10, Name = "Kaynarca", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 11, Name = "Kocaali", CreatedDate = defaultDate, UpdatedDate = defaultDate, CityId = 54 },
                new District { Id = 12, Name = "Pamukova", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 13, Name = "Sapanca", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 14, Name = "Serdivan", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 15, Name = "Söğütlü", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54},
                new District { Id = 16, Name = "Taraklı", CreatedDate = defaultDate, UpdatedDate = defaultDate , CityId = 54}
            };

            return districts;
        }
    }
}
