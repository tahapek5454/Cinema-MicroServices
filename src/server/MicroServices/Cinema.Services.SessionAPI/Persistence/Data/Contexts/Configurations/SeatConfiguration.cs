using Cinema.Services.SessionAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.SessionAPI.Persistence.Data.Contexts.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasData(SeedDatas());
        }

        private IEnumerable<Seat> SeedDatas()
        {
            List<Seat> seats = new List<Seat>
            {
                new Seat { Id = 1, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "A-1" },
                new Seat { Id = 2, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "A-2" },
                new Seat { Id = 3, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "A-3" },
                new Seat { Id = 4, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "A-4" },
                new Seat { Id = 5, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "A-5" },
                new Seat { Id = 6, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "B-1" },
                new Seat { Id = 7, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "B-2" },
                new Seat { Id = 8, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "B-3" },
                new Seat { Id = 9, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "B-4" },
                new Seat { Id = 10, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "B-5" },
                new Seat { Id = 11, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "C-1" },
                new Seat { Id = 12, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "C-2" },
                new Seat { Id = 13, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "C-3" },
                new Seat { Id = 14, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "C-4" },
                new Seat { Id = 15, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "C-5" },
                new Seat { Id = 16, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "D-1" },
                new Seat { Id = 17, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "D-2" },
                new Seat { Id = 18, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "D-3" },
                new Seat { Id = 19, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "D-4" },
                new Seat { Id = 20, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 1, SeatNumber = "D-5" },

                new Seat { Id = 21, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "A-1" },
                new Seat { Id = 22, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "A-2" },
                new Seat { Id = 23, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "A-3" },
                new Seat { Id = 24, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "A-4" },
                new Seat { Id = 25, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "A-5" },
                new Seat { Id = 26, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "B-1" },
                new Seat { Id = 27, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "B-2" },
                new Seat { Id = 28, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "B-3" },
                new Seat { Id = 29, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "B-4" },
                new Seat { Id = 30, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "B-5" },
                new Seat { Id = 31, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "C-1" },
                new Seat { Id = 32, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "C-2" },
                new Seat { Id = 33, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "C-3" },
                new Seat { Id = 34, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "C-4" },
                new Seat { Id = 35, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "C-5" },
                new Seat { Id = 36, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "D-1" },
                new Seat { Id = 37, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "D-2" },
                new Seat { Id = 38, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "D-3" },
                new Seat { Id = 39, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "D-4" },
                new Seat { Id = 40, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 2, SeatNumber = "D-5" },

                new Seat { Id = 41, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "A-1" },
                new Seat { Id = 42, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "A-2" },
                new Seat { Id = 43, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "A-3" },
                new Seat { Id = 44, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "A-4" },
                new Seat { Id = 45, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "A-5" },
                new Seat { Id = 46, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "B-1" },
                new Seat { Id = 47, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "B-2" },
                new Seat { Id = 48, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "B-3" },
                new Seat { Id = 49, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "B-4" },
                new Seat { Id = 50, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "B-5" },
                new Seat { Id = 51, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "C-1" },
                new Seat { Id = 52, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "C-2" },
                new Seat { Id = 53, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "C-3" },
                new Seat { Id = 54, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "C-4" },
                new Seat { Id = 55, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "C-5" },
                new Seat { Id = 56, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "D-1" },
                new Seat { Id = 57, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "D-2" },
                new Seat { Id = 58, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "D-3" },
                new Seat { Id = 59, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "D-4" },
                new Seat { Id = 60, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 3, SeatNumber = "D-5" },

                new Seat { Id = 61, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "A-1" },
                new Seat { Id = 62, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "A-2" },
                new Seat { Id = 63, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "A-3" },
                new Seat { Id = 64, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "A-4" },
                new Seat { Id = 65, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "A-5" },
                new Seat { Id = 66, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "B-1" },
                new Seat { Id = 67, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "B-2" },
                new Seat { Id = 68, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "B-3" },
                new Seat { Id = 69, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "B-4" },
                new Seat { Id = 70, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "B-5" },
                new Seat { Id = 71, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "C-1" },
                new Seat { Id = 72, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "C-2" },
                new Seat { Id = 73, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "C-3" },
                new Seat { Id = 74, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "C-4" },
                new Seat { Id = 75, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "C-5" },
                new Seat { Id = 76, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "D-1" },
                new Seat { Id = 77, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "D-2" },
                new Seat { Id = 78, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "D-3" },
                new Seat { Id = 79, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "D-4" },
                new Seat { Id = 80, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 4, SeatNumber = "D-5" },

                new Seat { Id = 81, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "A-1" },
                new Seat { Id = 82, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "A-2" },
                new Seat { Id = 83, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "A-3" },
                new Seat { Id = 84, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "A-4" },
                new Seat { Id = 85, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "A-5" },
                new Seat { Id = 86, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "B-1" },
                new Seat { Id = 87, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "B-2" },
                new Seat { Id = 88, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "B-3" },
                new Seat { Id = 89, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "B-4" },
                new Seat { Id = 90, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "B-5" },
                new Seat { Id = 91, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "C-1" },
                new Seat { Id = 92, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "C-2" },
                new Seat { Id = 93, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "C-3" },
                new Seat { Id = 94, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "C-4" },
                new Seat { Id = 95, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "C-5" },
                new Seat { Id = 96, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "D-1" },
                new Seat { Id = 97, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "D-2" },
                new Seat { Id = 98, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "D-3" },
                new Seat { Id = 99, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "D-4" },
                new Seat { Id = 100, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 5, SeatNumber = "D-5" },

                new Seat { Id = 101, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "A-1" },
                new Seat { Id = 102, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "A-2" },
                new Seat { Id = 103, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "A-3" },
                new Seat { Id = 104, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "A-4" },
                new Seat { Id = 105, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "A-5" },
                new Seat { Id = 106, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "B-1" },
                new Seat { Id = 107, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "B-2" },
                new Seat { Id = 108, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "B-3" },
                new Seat { Id = 109, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "B-4" },
                new Seat { Id = 110, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "B-5" },
                new Seat { Id = 111, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "C-1" },
                new Seat { Id = 112, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "C-2" },
                new Seat { Id = 113, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "C-3" },
                new Seat { Id = 114, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "C-4" },
                new Seat { Id = 115, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "C-5" },
                new Seat { Id = 116, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "D-1" },
                new Seat { Id = 117, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "D-2" },
                new Seat { Id = 118, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "D-3" },
                new Seat { Id = 119, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "D-4" },
                new Seat { Id = 120, CreatedDate = new DateTime(2024, 3, 31), MovieTheaterId = 6, SeatNumber = "D-5" }

            };

            return seats;
        }
    }
}
