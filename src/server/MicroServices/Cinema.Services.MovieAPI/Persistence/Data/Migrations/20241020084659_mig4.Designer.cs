﻿// <auto-generated />
using System;
using Cinema.Services.MovieAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cinema.Services.MovieAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241020084659_mig4")]
    partial class mig4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cinema.Services.MovieAPI.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Point")
                        .HasColumnType("float");

                    b.Property<double>("Time")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Çocuklarının doğumundan sonraki ilk 40 günde yeni hayatlarına uyum sağlamaya çalışan bir anne ve babanın eğlenceli hikayesini konu alıyor.",
                            Description_EN = "It tells the entertaining story of a mother and father trying to adapt to their new lives in the first 40 days after the birth of their children.",
                            Name = "Lohusa",
                            Name_EN = "Lohusa",
                            Point = 7.4000000000000004,
                            Time = 1.5800000000000001,
                            UpdatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Çorum'da yaşayan Sadık (Ahmet Kural) ve ailesi, binlerce yıllık aile geleneğini devam ettirerek yoğurtçuluk yaparlar.<br/> Yoğurtları lezzeti ve şifası ile bilinir.<br/> Bu dillere destan yoğurdun sırrını ise ailenin en büyüğü olan Dede saklar ve yoğurtları...",
                            Description_EN = "Sadık (Ahmet Kural) and his family, living in Çorum, continue the age-old family tradition by engaging in yogurt production.<br/> Their yogurt is known for its delicious taste and healing properties.<br/> The secret of this legendary yogurt is guarded by the family's eldest, Dede, and the yogurts...",
                            Name = "Efsane",
                            Name_EN = "Legend",
                            Point = 5.2000000000000002,
                            Time = 1.45,
                            UpdatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Hayri, uzaya çıkan en genç insan olarak ün kazanıp üstün zekâlı öğrencilerin girdiği bir bilim teknik okuluna kabul alır.<br/> Artık mahallesinde çok az vakit geçirip çoğunlukla Yüz Yılın İcadı olarak hitap ettiği dev robot Hayrimatör üzerine çalışır...",
                            Description_EN = "Hayri gains fame as the youngest person to go to space and gets admitted to a science and technology school for exceptionally intelligent students.<br/> Now, spending very little time in his neighborhood, he mostly works on the giant robot he refers to as The Invention of the Century, which he calls Hayrimator...",
                            Name = "Rafadan Tayfa 4: Hayrimatör",
                            Name_EN = "Rafadan Tayfa 4: Hayrimatör",
                            Point = 8.0999999999999996,
                            Time = 1.3200000000000001,
                            UpdatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kolpaçino serisinin 3. filmi Kolpaçino 3. Devre'den sonra Kolpaçino 4 4'lük seyirci ile buluşmaya hazırlanıyor.<br/> Aralarındaki düşmanlığa son vermek ve hesaplaşmak isteyen Özgür ve Sabri, bir mekanda toplanırlar.<br/> Tayfun'un nişanından önce son ...",
                            Description_EN = "Following the third film in the Kolpaçino series, Kolpaçino 3. Devre, Kolpaçino 4 is getting ready to meet the audience with a score of 4 out of 4.<br/> Özgür and Sabri, who want to put an end to their enmity and settle the score, gather at a venue. Just before Tayfun's engagement, they aim to finalize their long-lasting rivalry...",
                            Name = "Kolpaçino 4 4'lük",
                            Name_EN = "Kolpaçino 4 4'lük",
                            Point = 4.5999999999999996,
                            Time = 1.3,
                            UpdatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Film, Cem Karaca'nın (İsmail Hacıoğlu) büyük başarılarından aşklarına; sürgünlerden, kayıplarına ve kavuşmalarına hayatını bütün iniş çıkışlarıyla gözler önüne seriyor.",
                            Description_EN = "The movie unfolds the life of Cem Karaca (played by İsmail Hacıoğlu), showcasing his significant achievements, love affairs, exiles, losses, and reunions with all the ups and downs.",
                            Name = "Cem Karaca'nın Gözyaşları",
                            Name_EN = "Cem Karaca'nın Gözyaşları",
                            Point = 9.0,
                            Time = 2.0299999999999998,
                            UpdatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "4 kardeş Deniz, Derya, Ali ve Yaz'ın sıradan hayatları, anne ve babalarının aslında birer gizli ajanlar olduklarını öğrenmeli ile bir anda değişir.<br/> Olağanüstü teknolojilerin bünyesinde korunduğu TeknoStar için çalışan anne ve babaları, bu teknoloj...",
                            Description_EN = "The ordinary lives of four siblings, Deniz, Derya, Ali, and Yaz, take a sudden turn when they discover that their parents are actually secret agents.<br/> Their parents work for TeknoStar, where extraordinary technologies are protected.<br/> The siblings find themselves caught up in a world of espionage, adventure, and high-tech intrigue as they navigate the challenges and mysteries that come with their parents' double lives.",
                            Name = "Kardeş Takımı",
                            Name_EN = "Brother Team",
                            Point = 7.5,
                            Time = 1.3500000000000001,
                            UpdatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Bir grup genç uzay kolonizatörü, terk edilmiş bir uzay istasyonunun derinliklerini araştırırken evrendeki en korkunç yaşam formuyla yüz yüze gelir.Bir grup genç uzay kolonizatörü, terk edilmiş bir uzay istasyonunun derinliklerini araştırırken evrendeki en korkunç yaşam formuyla yüz yüze gelir.",
                            Description_EN = "While exploring the depths of an abandoned space station, a group of young space colonisers come face to face with the most terrifying life form in the universe.While exploring the depths of an abandoned space station, a group of young space colonisers come face to face with the most terrifying life form in the universe.",
                            Name = "Alien",
                            Name_EN = "Alien",
                            Point = 7.5,
                            Time = 1.3500000000000001,
                            UpdatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 5,
                            CreatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Wolverine yaralarından kurtulmaya çalışırken yolu boşboğaz Deadpool ile kesişir. Ortak bir düşmanı yenmek için takım olurlar.",
                            Description_EN = "Wolverine is recovering from his injuries when he crosses paths with the loud-mouthed Deadpool. They team up to defeat a common enemy.",
                            Name = "Deadpool & Wolverine",
                            Name_EN = "Deadpool & Wolverine",
                            Point = 7.5,
                            Time = 2.0699999999999998,
                            UpdatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Karikatürist Jim Davis tarafından 1978 yılında yaratılan ve hikâyeleri karikatür sayfalarından televizyona kadar uzanan Garfield'ın animasyon filmi, kayıp babası Vic ile yolları yeniden kesişen Garfield'ın, arkadaşı Ollie ile birlikte yaşadığı maceraları konu ediniyor.",
                            Description_EN = "The animated film of Garfield, created by cartoonist Jim Davis in 1978 and whose stories have spread from the cartoon pages to television, is about the adventures of Garfield, whose paths cross again with his missing father Vic, together with his friend Ollie.",
                            Name = "Garfield",
                            Name_EN = "Garfield",
                            Point = 7.5,
                            Time = 1.4099999999999999,
                            UpdatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ters Yüz 2, artık bir ergen olan ve çok daha çılgın, kişiselleştirilmiş duygularla uğraşmak zorunda olan Genç Riley'nin maceralarını konu ediyor.",
                            Description_EN = "Inside Out 2 follows the adventures of Young Riley, who is now a teenager and has to deal with much crazier, personalised emotions.",
                            Name = "Ters Yüz 2",
                            Name_EN = "Inside Out 2",
                            Point = 7.5,
                            Time = 1.3600000000000001,
                            UpdatedDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Cinema.Services.MovieAPI.Domain.Entities.MovieImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieImages");
                });

            modelBuilder.Entity("Cinema.Services.MovieAPI.Domain.Entities.MovieImage", b =>
                {
                    b.HasOne("Cinema.Services.MovieAPI.Domain.Entities.Movie", "Movie")
                        .WithMany("MovieImages")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Cinema.Services.MovieAPI.Domain.Entities.Movie", b =>
                {
                    b.Navigation("MovieImages");
                });
#pragma warning restore 612, 618
        }
    }
}
