using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPlantsMvc.Data.Migrations
{
    public partial class RemoveColumnModulesTotalModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalModules",
                table: "Farms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalModules",
                table: "Farms",
                nullable: false,
                defaultValue: 0);
        }
    }
}
