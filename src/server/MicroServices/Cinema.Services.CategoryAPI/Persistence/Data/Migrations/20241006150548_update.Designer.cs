﻿// <auto-generated />
using System;
using Cinema.Services.CategoryAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cinema.Services.CategoryAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241006150548_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cinema.Services.CategoryAPI.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_EN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Komedi",
                            Name_EN = "Comedy"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Animasyon",
                            Name_EN = "Animation"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Biyografik",
                            Name_EN = "Biographical"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
