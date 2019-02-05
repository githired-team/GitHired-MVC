using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHired_MVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GitHubLink = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Focus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DesiredPosition = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Skill = table.Column<string>(nullable: true),
                    ResumeLink = table.Column<string>(nullable: true),
                    CoverLetter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Focus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Focus_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FocusID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Board_Focus_FocusID",
                        column: x => x.FocusID,
                        principalTable: "Focus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Column",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Column_Board_BoardID",
                        column: x => x.BoardID,
                        principalTable: "Board",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnID = table.Column<int>(nullable: false),
                    ResumeCheck = table.Column<bool>(nullable: false),
                    CoverLetterCheck = table.Column<bool>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Wage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Card_Column_ColumnID",
                        column: x => x.ColumnID,
                        principalTable: "Column",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Avatar", "Email", "GitHubLink", "Name" },
                values: new object[] { 1, "Test Avatar", "test@test.com", "http://www.github.com/testuser", "Test User" });

            migrationBuilder.InsertData(
                table: "Focus",
                columns: new[] { "ID", "CoverLetter", "DesiredPosition", "Location", "Name", "ResumeLink", "Skill", "UserID" },
                values: new object[] { 1, "Test Cover Letter", "Test Position", "Testville, USA", "Test Focus", "Test Resume Link", "ASP.NET Core", 1 });

            migrationBuilder.InsertData(
                table: "Board",
                columns: new[] { "ID", "FocusID", "Name" },
                values: new object[] { 1, 1, "Default Board" });

            migrationBuilder.InsertData(
                table: "Column",
                columns: new[] { "ID", "BoardID", "Name", "Order" },
                values: new object[] { 1, 1, "Default Column 1", 1 });

            migrationBuilder.InsertData(
                table: "Column",
                columns: new[] { "ID", "BoardID", "Name", "Order" },
                values: new object[] { 2, 1, "Default Column 2", 2 });

            migrationBuilder.InsertData(
                table: "Column",
                columns: new[] { "ID", "BoardID", "Name", "Order" },
                values: new object[] { 3, 1, "Default Column 3", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Board_FocusID",
                table: "Board",
                column: "FocusID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_ColumnID",
                table: "Card",
                column: "ColumnID");

            migrationBuilder.CreateIndex(
                name: "IX_Column_BoardID",
                table: "Column",
                column: "BoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Focus_UserID",
                table: "Focus",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Column");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "Focus");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
