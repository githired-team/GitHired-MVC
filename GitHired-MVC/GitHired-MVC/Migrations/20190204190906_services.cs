using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHired_MVC.Migrations
{
    public partial class services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Focus_UserID",
                table: "Focus",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Column_BoardID",
                table: "Column",
                column: "BoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Card_ColumnID",
                table: "Card",
                column: "ColumnID");

            migrationBuilder.CreateIndex(
                name: "IX_Board_FocusID",
                table: "Board",
                column: "FocusID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Board_Focus_FocusID",
                table: "Board",
                column: "FocusID",
                principalTable: "Focus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Column_ColumnID",
                table: "Card",
                column: "ColumnID",
                principalTable: "Column",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Column_Board_BoardID",
                table: "Column",
                column: "BoardID",
                principalTable: "Board",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Focus_User_UserID",
                table: "Focus",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_Focus_FocusID",
                table: "Board");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Column_ColumnID",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Column_Board_BoardID",
                table: "Column");

            migrationBuilder.DropForeignKey(
                name: "FK_Focus_User_UserID",
                table: "Focus");

            migrationBuilder.DropIndex(
                name: "IX_Focus_UserID",
                table: "Focus");

            migrationBuilder.DropIndex(
                name: "IX_Column_BoardID",
                table: "Column");

            migrationBuilder.DropIndex(
                name: "IX_Card_ColumnID",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Board_FocusID",
                table: "Board");
        }
    }
}
