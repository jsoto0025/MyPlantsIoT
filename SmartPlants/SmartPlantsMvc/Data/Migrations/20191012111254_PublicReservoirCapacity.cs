using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPlantsMvc.Data.Migrations
{
    public partial class PublicReservoirCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Reservoirs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Reservoirs");
        }
    }
}
