using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Services.MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    ParenId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieComments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MovieComments",
                columns: new[] { "Id", "Comment", "CreatedDate", "LikeCount", "MovieId", "ParenId", "UpdatedDate", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "Film harikaydı, kesinlikle tavsiye ederim! Oyunculuk ve hikaye akışı çok iyiydi.", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8, null, null, 1, "tahapek5454" },
                    { 2, "Sürükleyici bir yapım, bir an bile sıkılmadan izledim. Finali de etkileyiciydi!", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, null, null, 2, "deren16" },
                    { 3, "Beklentilerimin çok üzerinde çıktı. Görsel efektler ve atmosfer çok başarılıydı.", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, null, null, 3, "mrtGlr06" },
                    { 4, "Senaryo oldukça derindi, düşündürücü bir film olmuş. Özellikle karakter gelişimleri etkileyiciydi.", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, null, null, 4, "g.kaya34" },
                    { 5, "Film boyunca heyecan hiç azalmadı. Aksiyon ve dram dengesi mükemmeldi!", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, null, null, 1, "tahapek5454" },
                    { 6, "Kesinlikle size katılıyorum yorumlarınız harika 🤩", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, 5, null, 2, "deren16" },
                    { 7, "Hikayesi çok özgündü ve duygusal yönü oldukça güçlüydü. İzlerken çok etkilendim.", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, null, null, 3, "mrtGlr06" },
                    { 8, "Filmdeki müzikler ve sinematografi çok başarılıydı. Gerçekten izlenmeye değer bir yapım.", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, null, null, 4, "g.kaya34" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_MovieId",
                table: "MovieComments",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieComments");
        }
    }
}
