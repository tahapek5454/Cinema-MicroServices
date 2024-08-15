using Cinema.Services.BranchAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.BranchAPI.Data.Context.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(SeedDatas());
        }


        private IEnumerable<City> SeedDatas()
        {
            DateTime defaultDate = new DateTime(2024, 2, 5);
            List<City> cities = new List<City>
            {
                new City { Id = 1, Name = "Adana", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 2, Name = "Adıyaman", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 3, Name = "Afyonkarahisar", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 4, Name = "Ağrı", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 5, Name = "Amasya", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 6, Name = "Ankara", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 7, Name = "Antalya", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 8, Name = "Artvin", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 9, Name = "Aydın", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 10, Name = "Balıkesir", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 11, Name = "Bilecik", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 12, Name = "Bingöl", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 13, Name = "Bitlis", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 14, Name = "Bolu", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 15, Name = "Burdur", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 16, Name = "Bursa", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 17, Name = "Çanakkale", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 18, Name = "Çankırı", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 19, Name = "Çorum", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 20, Name = "Denizli", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 21, Name = "Diyarbakır", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 22, Name = "Edirne", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 23, Name = "Elazığ", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 24, Name = "Erzincan", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 25, Name = "Erzurum", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 26, Name = "Eskişehir", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 27, Name = "Gaziantep", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 28, Name = "Giresun", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 29, Name = "Gümüşhane", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 30, Name = "Hakkari", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 31, Name = "Hatay", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 32, Name = "Isparta", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 33, Name = "Mersin", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 34, Name = "İstanbul", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 35, Name = "İzmir", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 36, Name = "Kars", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 37, Name = "Kastamonu", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 38, Name = "Kayseri", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 39, Name = "Kırklareli", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 40, Name = "Kırşehir", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 41, Name = "Kocaeli", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 42, Name = "Konya", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 43, Name = "Kütahya", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 44, Name = "Malatya", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 45, Name = "Manisa", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 46, Name = "Kahramanmaraş", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 47, Name = "Mardin", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 48, Name = "Muğla", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 49, Name = "Muş", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 50, Name = "Nevşehir", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 51, Name = "Niğde", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 52, Name = "Ordu", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 53, Name = "Rize", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 54, Name = "Sakarya", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 55, Name = "Samsun", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 56, Name = "Siirt", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 57, Name = "Sinop", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 58, Name = "Sivas", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 59, Name = "Tekirdağ", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 60, Name = "Tokat", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 61, Name = "Trabzon", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 62, Name = "Tunceli", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 63, Name = "Şanlıurfa", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 64, Name = "Uşak", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 65, Name = "Van", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 66, Name = "Yozgat", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 67, Name = "Zonguldak", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 68, Name = "Aksaray", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 69, Name = "Bayburt", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 70, Name = "Karaman", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 71, Name = "Kırıkkale", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 72, Name = "Batman", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 73, Name = "Şırnak", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 74, Name = "Bartın", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 75, Name = "Ardahan", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 76, Name = "Iğdır", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 77, Name = "Yalova", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 78, Name = "Karabük", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 79, Name = "Kilis", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 80, Name = "Osmaniye", CreatedDate = defaultDate, UpdatedDate = defaultDate },
                new City { Id = 81, Name = "Düzce", CreatedDate = defaultDate, UpdatedDate = defaultDate }

            };

            return cities;
        }
    }
}
