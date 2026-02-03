using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parking.api.Migrations
{
    /// <inheritdoc />
    public partial class SpotClassChnage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_ParkingZones_ZoneId",
                table: "ParkingSpots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_ZoneId",
                table: "ParkingSpots");

            migrationBuilder.AddColumn<int>(
                name: "ParkingZoneId",
                table: "ParkingSpots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ParkingZoneId",
                table: "ParkingSpots",
                column: "ParkingZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_ParkingZones_ParkingZoneId",
                table: "ParkingSpots",
                column: "ParkingZoneId",
                principalTable: "ParkingZones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_ParkingZones_ParkingZoneId",
                table: "ParkingSpots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_ParkingZoneId",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "ParkingZoneId",
                table: "ParkingSpots");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ZoneId",
                table: "ParkingSpots",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_ParkingZones_ZoneId",
                table: "ParkingSpots",
                column: "ZoneId",
                principalTable: "ParkingZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
