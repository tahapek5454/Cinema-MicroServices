using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Services.SessionAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "SeatSessionStatus");

            migrationBuilder.AddColumn<int>(
                name: "ReservedStatus",
                table: "SeatSessionStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedStatus",
                table: "SeatSessionStatus");

            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "SeatSessionStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
