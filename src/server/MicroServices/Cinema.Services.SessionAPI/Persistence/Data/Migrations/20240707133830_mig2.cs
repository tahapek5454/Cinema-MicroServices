using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Services.SessionAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatStatuses");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Sessions");

            migrationBuilder.CreateTable(
                name: "MovieTheater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MovieTheaterNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheater", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatSessionStatus",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    Reserved = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatSessionStatus", x => new { x.SessionId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_SeatSessionStatus_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeatSessionStatus_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MovieTheater",
                columns: new[] { "Id", "BranchId", "Capacity", "CreatedDate", "MovieTheaterNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieTheaterId",
                table: "Sessions",
                column: "MovieTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_MovieTheaterId",
                table: "Seats",
                column: "MovieTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatSessionStatus_SeatId",
                table: "SeatSessionStatus",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatSessionStatus_SessionId_SeatId",
                table: "SeatSessionStatus",
                columns: new[] { "SessionId", "SeatId" },
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_MovieTheater_MovieTheaterId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheater_MovieTheaterId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "MovieTheater");

            migrationBuilder.DropTable(
                name: "SeatSessionStatus");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_MovieTheaterId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Seats_MovieTheaterId",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SeatStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reserved = table.Column<bool>(type: "bit", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatStatuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Capacity",
                value: 20);
        }
    }
}
