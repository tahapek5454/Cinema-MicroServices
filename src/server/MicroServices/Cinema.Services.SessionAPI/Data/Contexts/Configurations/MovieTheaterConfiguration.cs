using Cinema.Services.SessionAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.SessionAPI.Data.Contexts.Configurations
{
    public class MovieTheaterConfiguration : IEntityTypeConfiguration<MovieTheater>
    {
        public void Configure(EntityTypeBuilder<MovieTheater> builder)
        {
            builder.HasData(SeedDatas());
        }


        private IEnumerable<MovieTheater> SeedDatas()
        {
            yield return new MovieTheater()
            {
                Id = 1,
                BranchId = 1,
                Capacity = 20,
                CreatedDate = new DateTime(2024, 3, 31),
                MovieTheaterNumber = 1,
            
            };

            yield return new MovieTheater()
            {
                Id = 2,
                BranchId = 1,
                Capacity = 20,
                CreatedDate = new DateTime(2024, 3, 31),
                MovieTheaterNumber = 2,

            };

            yield return new MovieTheater()
            {
                Id = 3,
                BranchId = 1,
                Capacity = 20,
                CreatedDate = new DateTime(2024, 3, 31),
                MovieTheaterNumber = 3,

            };

            yield return new MovieTheater()
            {
                Id = 4,
                BranchId = 1,
                Capacity = 20,
                CreatedDate = new DateTime(2024, 3, 31),
                MovieTheaterNumber = 4,

            };

            yield return new MovieTheater()
            {
                Id = 5,
                BranchId = 1,
                Capacity = 20,
                CreatedDate = new DateTime(2024, 3, 31),
                MovieTheaterNumber = 5,

            };

            yield return new MovieTheater()
            {
                Id = 6,
                BranchId = 1,
                Capacity = 20,
                CreatedDate = new DateTime(2024, 3, 31),
                MovieTheaterNumber = 6,

            };
        }
    }
}
