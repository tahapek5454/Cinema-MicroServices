using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaStateMachine.Service.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationStateInstance",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ReservationCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SeatIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieTheaterId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStateInstance", x => x.CorrelationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationStateInstance");
        }
    }
}
