using Microsoft.EntityFrameworkCore.Migrations;

namespace Kingpin.Tier.Contexts.Migrations
{
    public partial class ImageUri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "ApplicationRole",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "ApplicationRole");
        }
    }
}
