using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { 2, new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "Surname", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "admin", "secret.123", "admin", new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { 2, new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer@gmail.com", "customer", "123", "customer", new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
