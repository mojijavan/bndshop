using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressManagement.Infrastructure.EFCore.Migrations
{
    public partial class addisremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Addresses");
        }
    }
}
