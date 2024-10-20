using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Services.MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Description_EN", "Name", "Name_EN", "Point", "Time", "UpdatedDate" },
                values: new object[,]
                {
                    { 7, 4, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bir grup genç uzay kolonizatörü, terk edilmiş bir uzay istasyonunun derinliklerini araştırırken evrendeki en korkunç yaşam formuyla yüz yüze gelir.Bir grup genç uzay kolonizatörü, terk edilmiş bir uzay istasyonunun derinliklerini araştırırken evrendeki en korkunç yaşam formuyla yüz yüze gelir.", "While exploring the depths of an abandoned space station, a group of young space colonisers come face to face with the most terrifying life form in the universe.While exploring the depths of an abandoned space station, a group of young space colonisers come face to face with the most terrifying life form in the universe.", "Alien", "Alien", 7.5, 1.3500000000000001, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 5, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wolverine yaralarından kurtulmaya çalışırken yolu boşboğaz Deadpool ile kesişir. Ortak bir düşmanı yenmek için takım olurlar.", "Wolverine is recovering from his injuries when he crosses paths with the loud-mouthed Deadpool. They team up to defeat a common enemy.", "Deadpool & Wolverine", "Deadpool & Wolverine", 7.5, 2.0699999999999998, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karikatürist Jim Davis tarafından 1978 yılında yaratılan ve hikâyeleri karikatür sayfalarından televizyona kadar uzanan Garfield'ın animasyon filmi, kayıp babası Vic ile yolları yeniden kesişen Garfield'ın, arkadaşı Ollie ile birlikte yaşadığı maceraları konu ediniyor.", "The animated film of Garfield, created by cartoonist Jim Davis in 1978 and whose stories have spread from the cartoon pages to television, is about the adventures of Garfield, whose paths cross again with his missing father Vic, together with his friend Ollie.", "Garfield", "Garfield", 7.5, 1.4099999999999999, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ters Yüz 2, artık bir ergen olan ve çok daha çılgın, kişiselleştirilmiş duygularla uğraşmak zorunda olan Genç Riley'nin maceralarını konu ediyor.", "Inside Out 2 follows the adventures of Young Riley, who is now a teenager and has to deal with much crazier, personalised emotions.", "Ters Yüz 2", "Inside Out 2", 7.5, 1.3600000000000001, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
