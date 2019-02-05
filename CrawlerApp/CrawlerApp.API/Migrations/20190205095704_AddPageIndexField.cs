using Microsoft.EntityFrameworkCore.Migrations;

namespace CrawlerApp.API.Migrations
{
    public partial class AddPageIndexField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageIndex",
                table: "Apps",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageIndex",
                table: "Apps");
        }
    }
}
