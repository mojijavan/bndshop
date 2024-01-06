using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryMangement.Infrastructure.EFCore.Migrations
{
    public partial class aDDcOLLEGEPRICE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PurchasePrice",
                table: "Inventory",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Inventory");
        }
    }
}
