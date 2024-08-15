using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Services.BranchAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adana", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adıyaman", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afyonkarahisar", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ağrı", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amasya", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ankara", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antalya", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artvin", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aydın", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balıkesir", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilecik", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bingöl", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bitlis", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolu", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burdur", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bursa", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çanakkale", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çankırı", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çorum", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denizli", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diyarbakır", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edirne", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elazığ", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erzincan", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erzurum", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eskişehir", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaziantep", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giresun", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gümüşhane", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hakkari", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hatay", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isparta", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mersin", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "İzmir", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kars", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kastamonu", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kayseri", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kırklareli", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kırşehir", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kocaeli", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konya", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kütahya", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malatya", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manisa", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kahramanmaraş", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mardin", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muğla", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muş", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nevşehir", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niğde", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ordu", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rize", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sakarya", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsun", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siirt", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sivas", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tekirdağ", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokat", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trabzon", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunceli", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şanlıurfa", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uşak", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yozgat", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zonguldak", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aksaray", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bayburt", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karaman", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kırıkkale", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şırnak", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bartın", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ardahan", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iğdır", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yalova", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karabük", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kilis", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osmaniye", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Düzce", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adapazarı", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akyazı", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arifiye", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erenler", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferizli", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Geyve", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hendek", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karapürçek", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karasu", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaynarca", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kocaali", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pamukova", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sapanca", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serdivan", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Söğütlü", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 54, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taraklı", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "Address_EN", "CreatedDate", "Description", "Description_EN", "DistrictId", "Name", "UpdatedDate" },
                values: new object[] { 1, "Arabacıalanı, 54050 Serdivan/Sakarya", "Arabacıalanı, 54050 Serdivan/Sakarya English", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serdivan AVM'de Paribu Cineverse İle Kesintisiz Film Keyfi", "Uninterrupted Movie Pleasure with Cinema Maxiums at Serdivan Shopping Mall", 14, "Serdivan Paribu Cineverse", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DistrictId",
                table: "Branches",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
