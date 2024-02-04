using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Services.MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedDate", "Description", "Description_EN", "Name", "Name_EN", "Point", "Time", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çocuklarının doğumundan sonraki ilk 40 günde yeni hayatlarına uyum sağlamaya çalışan bir anne ve babanın eğlenceli hikayesini konu alıyor.", "It tells the entertaining story of a mother and father trying to adapt to their new lives in the first 40 days after the birth of their children.", "Lohusa", "Lohusa", 7.4000000000000004, 1.5800000000000001, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çorum'da yaşayan Sadık (Ahmet Kural) ve ailesi, binlerce yıllık aile geleneğini devam ettirerek yoğurtçuluk yaparlar.<br/> Yoğurtları lezzeti ve şifası ile bilinir.<br/> Bu dillere destan yoğurdun sırrını ise ailenin en büyüğü olan Dede saklar ve yoğurtları...", "Sadık (Ahmet Kural) and his family, living in Çorum, continue the age-old family tradition by engaging in yogurt production.<br/> Their yogurt is known for its delicious taste and healing properties.<br/> The secret of this legendary yogurt is guarded by the family's eldest, Dede, and the yogurts...", "Efsane", "Legend", 5.2000000000000002, 1.45, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hayri, uzaya çıkan en genç insan olarak ün kazanıp üstün zekâlı öğrencilerin girdiği bir bilim teknik okuluna kabul alır.<br/> Artık mahallesinde çok az vakit geçirip çoğunlukla Yüz Yılın İcadı olarak hitap ettiği dev robot Hayrimatör üzerine çalışır...", "Hayri gains fame as the youngest person to go to space and gets admitted to a science and technology school for exceptionally intelligent students.<br/> Now, spending very little time in his neighborhood, he mostly works on the giant robot he refers to as The Invention of the Century, which he calls Hayrimator...", "Rafadan Tayfa 4: Hayrimatör", "Rafadan Tayfa 4: Hayrimatör", 8.0999999999999996, 1.3200000000000001, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kolpaçino serisinin 3. filmi Kolpaçino 3. Devre'den sonra Kolpaçino 4 4'lük seyirci ile buluşmaya hazırlanıyor.<br/> Aralarındaki düşmanlığa son vermek ve hesaplaşmak isteyen Özgür ve Sabri, bir mekanda toplanırlar.<br/> Tayfun'un nişanından önce son ...", "Following the third film in the Kolpaçino series, Kolpaçino 3. Devre, Kolpaçino 4 is getting ready to meet the audience with a score of 4 out of 4.<br/> Özgür and Sabri, who want to put an end to their enmity and settle the score, gather at a venue. Just before Tayfun's engagement, they aim to finalize their long-lasting rivalry...", "Kolpaçino 4 4'lük", "Kolpaçino 4 4'lük", 4.5999999999999996, 1.3, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film, Cem Karaca'nın (İsmail Hacıoğlu) büyük başarılarından aşklarına; sürgünlerden, kayıplarına ve kavuşmalarına hayatını bütün iniş çıkışlarıyla gözler önüne seriyor.", "The movie unfolds the life of Cem Karaca (played by İsmail Hacıoğlu), showcasing his significant achievements, love affairs, exiles, losses, and reunions with all the ups and downs.", "Cem Karaca'nın Gözyaşları", "Cem Karaca'nın Gözyaşları", 9.0, 2.0299999999999998, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 kardeş Deniz, Derya, Ali ve Yaz'ın sıradan hayatları, anne ve babalarının aslında birer gizli ajanlar olduklarını öğrenmeli ile bir anda değişir.<br/> Olağanüstü teknolojilerin bünyesinde korunduğu TeknoStar için çalışan anne ve babaları, bu teknoloj...", "The ordinary lives of four siblings, Deniz, Derya, Ali, and Yaz, take a sudden turn when they discover that their parents are actually secret agents.<br/> Their parents work for TeknoStar, where extraordinary technologies are protected.<br/> The siblings find themselves caught up in a world of espionage, adventure, and high-tech intrigue as they navigate the challenges and mysteries that come with their parents' double lives.", "Kardeş Takımı", "Brother Team", 7.5, 1.3500000000000001, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
