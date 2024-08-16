using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Services.SessionAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SeatSessionStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SeatSessionStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
