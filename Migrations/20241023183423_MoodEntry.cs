using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class MoodEntry : Migration
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
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cell = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoodEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDate = table.Column<DateTime>(name: "Entry Date", type: "datetime2", nullable: false),
                    Mood = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoodEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoodEntries_Membership_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Membership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "MoodEntries",
                columns: new[] { "Id", "Entry Date", "MembersId", "Mood", "Notes" },
                values: new object[] { 1, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, "Sad", "Today was a tough day" });

            migrationBuilder.InsertData(
                table: "MoodEntries",
                columns: new[] { "Id", "Entry Date", "MembersId", "Mood", "Notes" },
                values: new object[] { 2, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 2, "Happy", "Today was a great day" });

            migrationBuilder.InsertData(
                table: "MoodEntries",
                columns: new[] { "Id", "Entry Date", "MembersId", "Mood", "Notes" },
                values: new object[] { 3, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 3, "Okay", "Today was neutral" });

            migrationBuilder.CreateIndex(
                name: "IX_MoodEntries_MembersId",
                table: "MoodEntries",
                column: "MembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoodEntries");

            migrationBuilder.DropTable(
                name: "Membership");
        }
    }
}
