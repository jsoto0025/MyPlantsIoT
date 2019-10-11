using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPlantsMvc.Data.Migrations
{
    public partial class UpdatePrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlantTypes",
                newName: "PlantTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Modules",
                newName: "ModuleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Farms",
                newName: "FarmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlantTypeId",
                table: "PlantTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Modules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FarmId",
                table: "Farms",
                newName: "Id");
        }
    }
}
