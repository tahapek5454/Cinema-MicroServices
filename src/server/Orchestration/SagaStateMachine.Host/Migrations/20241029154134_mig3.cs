using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaStateMachine.Host.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTheaterId",
                table: "ReservationStateInstance");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ReservationStateInstance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterId",
                table: "ReservationStateInstance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ReservationStateInstance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
