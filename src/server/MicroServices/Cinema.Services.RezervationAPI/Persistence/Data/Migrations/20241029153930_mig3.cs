using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Services.RezervationAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTheaterId",
                table: "Rezervations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rezervations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterId",
                table: "Rezervations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Rezervations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
