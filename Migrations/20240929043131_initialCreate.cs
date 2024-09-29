using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "Cell", "Email", "FirstName", "LastName" },
                values: new object[] { 1, null, "MonsterEatsCookies@gmail.com", "Cookie", "Monster" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "Cell", "Email", "FirstName", "LastName" },
                values: new object[] { 2, null, "CookieCrispCereal@aol.com", "Cookie", "Crisp" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "Cell", "Email", "FirstName", "LastName" },
                values: new object[] { 3, null, "ennis@gmail.nmc.edu", "Sarah", "Ennis" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");
        }
    }
}
