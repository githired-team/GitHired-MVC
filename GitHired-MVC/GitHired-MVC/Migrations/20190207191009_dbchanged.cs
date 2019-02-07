using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHired_MVC.Migrations
{
    public partial class dbchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GHLink1",
                table: "Card",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GHLink2",
                table: "Card",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GHLink3",
                table: "Card",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GHLink1",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "GHLink2",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "GHLink3",
                table: "Card");
        }
    }
}
