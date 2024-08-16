using Cinema.Services.SessionAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.SessionAPI.Persistence.Data.Contexts.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasData(SeedDatas());
        }

        private IEnumerable<Session> SeedDatas()
        {
            yield return new Session()
            {
                Id = 1,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 12, 30, 0),
                MovieId = 1,
                MovieTheaterId = 1,
                Price = 100
            };

            yield return new Session()
            {
                Id = 2,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 17, 30, 0),
                MovieId = 1,
                MovieTheaterId = 1,
                Price = 100,

            };

            yield return new Session()
            {
                Id = 3,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 21, 0, 0),
                MovieId = 1,
                MovieTheaterId = 1,
                Price = 100
            };

            yield return new Session()
            {
                Id = 4,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 10, 0, 0),
                MovieId = 2,
                MovieTheaterId = 2,
                Price = 100
            };

            yield return new Session()
            {
                Id = 5,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 14, 30, 0),
                MovieId = 2,
                MovieTheaterId = 2,
                Price = 100
            };

            yield return new Session()
            {
                Id = 6,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 22, 0, 0),
                MovieId = 2,
                MovieTheaterId = 2,
                Price = 100
            };

            yield return new Session()
            {
                Id = 7,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 11, 0, 0),
                MovieId = 3,
                MovieTheaterId = 3,
                Price = 100
            };

            yield return new Session()
            {
                Id = 8,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 18, 0, 0),
                MovieId = 3,
                MovieTheaterId = 3,
                Price = 100
            };

            yield return new Session()
            {
                Id = 9,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 13, 0, 0),
                MovieId = 4,
                MovieTheaterId = 4,
                Price = 100
            };

            yield return new Session()
            {
                Id = 10,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 18, 0, 0),
                MovieId = 5,
                MovieTheaterId = 5,
                Price = 100
            };

            yield return new Session()
            {
                Id = 11,
                CreatedDate = new DateTime(2024, 3, 31),
                UpdatedDate = new DateTime(2024, 3, 31),
                Date = new DateTime(2024, 3, 31, 20, 0, 0),
                MovieId = 6,
                MovieTheaterId = 6,
                Price = 100
            };

        }
    }
}
