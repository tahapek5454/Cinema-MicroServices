using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Services.SessionAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieTheaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MovieTheaterNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieTheaterId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_MovieTheaters_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieTheaterId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_MovieTheaters_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatSessionStatus",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    ReservedStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                table: "MovieTheaters",
                columns: new[] { "Id", "BranchId", "Capacity", "CreatedDate", "MovieTheaterNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 4, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 5, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null },
                    { 6, 1, 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreatedDate", "MovieTheaterId", "SeatNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A-1" },
                    { 2, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A-2" },
                    { 3, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A-3" },
                    { 4, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A-4" },
                    { 5, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A-5" },
                    { 6, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "B-1" },
                    { 7, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "B-2" },
                    { 8, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "B-3" },
                    { 9, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "B-4" },
                    { 10, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "B-5" },
                    { 11, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C-1" },
                    { 12, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C-2" },
                    { 13, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C-3" },
                    { 14, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C-4" },
                    { 15, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C-5" },
                    { 16, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "D-1" },
                    { 17, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "D-2" },
                    { 18, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "D-3" },
                    { 19, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "D-4" },
                    { 20, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "D-5" },
                    { 21, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A-1" },
                    { 22, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A-2" },
                    { 23, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A-3" },
                    { 24, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A-4" },
                    { 25, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A-5" },
                    { 26, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "B-1" },
                    { 27, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "B-2" },
                    { 28, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "B-3" },
                    { 29, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "B-4" },
                    { 30, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "B-5" },
                    { 31, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "C-1" },
                    { 32, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "C-2" },
                    { 33, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "C-3" },
                    { 34, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "C-4" },
                    { 35, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "C-5" },
                    { 36, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "D-1" },
                    { 37, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "D-2" },
                    { 38, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "D-3" },
                    { 39, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "D-4" },
                    { 40, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "D-5" },
                    { 41, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "A-1" },
                    { 42, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "A-2" },
                    { 43, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "A-3" },
                    { 44, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "A-4" },
                    { 45, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "A-5" },
                    { 46, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "B-1" },
                    { 47, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "B-2" },
                    { 48, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "B-3" },
                    { 49, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "B-4" },
                    { 50, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "B-5" },
                    { 51, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C-1" },
                    { 52, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C-2" },
                    { 53, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C-3" },
                    { 54, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C-4" },
                    { 55, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C-5" },
                    { 56, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "D-1" },
                    { 57, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "D-2" },
                    { 58, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "D-3" },
                    { 59, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "D-4" },
                    { 60, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "D-5" },
                    { 61, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "A-1" },
                    { 62, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "A-2" },
                    { 63, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "A-3" },
                    { 64, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "A-4" },
                    { 65, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "A-5" },
                    { 66, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "B-1" },
                    { 67, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "B-2" },
                    { 68, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "B-3" },
                    { 69, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "B-4" },
                    { 70, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "B-5" },
                    { 71, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C-1" },
                    { 72, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C-2" },
                    { 73, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C-3" },
                    { 74, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C-4" },
                    { 75, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C-5" },
                    { 76, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "D-1" },
                    { 77, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "D-2" },
                    { 78, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "D-3" },
                    { 79, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "D-4" },
                    { 80, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "D-5" },
                    { 81, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "A-1" },
                    { 82, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "A-2" },
                    { 83, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "A-3" },
                    { 84, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "A-4" },
                    { 85, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "A-5" },
                    { 86, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "B-1" },
                    { 87, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "B-2" },
                    { 88, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "B-3" },
                    { 89, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "B-4" },
                    { 90, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "B-5" },
                    { 91, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C-1" },
                    { 92, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C-2" },
                    { 93, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C-3" },
                    { 94, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C-4" },
                    { 95, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C-5" },
                    { 96, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "D-1" },
                    { 97, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "D-2" },
                    { 98, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "D-3" },
                    { 99, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "D-4" },
                    { 100, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "D-5" },
                    { 101, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "A-1" },
                    { 102, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "A-2" },
                    { 103, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "A-3" },
                    { 104, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "A-4" },
                    { 105, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "A-5" },
                    { 106, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "B-1" },
                    { 107, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "B-2" },
                    { 108, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "B-3" },
                    { 109, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "B-4" },
                    { 110, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "B-5" },
                    { 111, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "C-1" },
                    { 112, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "C-2" },
                    { 113, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "C-3" },
                    { 114, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "C-4" },
                    { 115, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "C-5" },
                    { 116, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "D-1" },
                    { 117, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "D-2" },
                    { 118, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "D-3" },
                    { 119, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "D-4" },
                    { 120, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "D-5" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CreatedDate", "Date", "MovieId", "MovieTheaterId", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 17, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 22, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 20, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, 100m, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieTheaterId",
                table: "Sessions",
                column: "MovieTheaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatSessionStatus");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "MovieTheaters");
        }
    }
}
