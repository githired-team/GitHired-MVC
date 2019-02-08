using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHired_MVC.Migrations
{
    public partial class day4rebuilddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GHLink1",
                table: "Focus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GHLink2",
                table: "Focus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GHLink3",
                table: "Focus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GHLink1",
                table: "Focus");

            migrationBuilder.DropColumn(
                name: "GHLink2",
                table: "Focus");

            migrationBuilder.DropColumn(
                name: "GHLink3",
                table: "Focus");
        }
    }
}
