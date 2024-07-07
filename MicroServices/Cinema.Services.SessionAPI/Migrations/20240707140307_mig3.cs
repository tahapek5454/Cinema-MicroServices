using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Services.SessionAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_MovieTheater_MovieTheaterId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheater_MovieTheaterId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheater",
                table: "MovieTheater");

            migrationBuilder.RenameTable(
                name: "MovieTheater",
                newName: "MovieTheaters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_MovieTheaters_MovieTheaterId",
                table: "Seats",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieTheaters_MovieTheaterId",
                table: "Sessions",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_MovieTheaters_MovieTheaterId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheaters_MovieTheaterId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters");

            migrationBuilder.RenameTable(
                name: "MovieTheaters",
                newName: "MovieTheater");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheater",
                table: "MovieTheater",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_MovieTheater_MovieTheaterId",
                table: "Seats",
                column: "MovieTheaterId",
                principalTable: "MovieTheater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieTheater_MovieTheaterId",
                table: "Sessions",
                column: "MovieTheaterId",
                principalTable: "MovieTheater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
