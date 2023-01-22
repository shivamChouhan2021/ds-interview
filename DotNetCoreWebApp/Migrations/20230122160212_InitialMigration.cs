using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreWebApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCode = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    MinimumQualification = table.Column<string>(nullable: true),
                    SortDescription = table.Column<string>(nullable: true),
                    LastApplyDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "shivamchouhan544@gmail.com", "Shivam Chouhan", "123456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 2, "navinkumar@gmail.com", "Navin Kumar", "1234567" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 3, "kiran@gmail.com", "Kiran Kher", "12345678" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCode", "LastApplyDate", "MinimumQualification", "SortDescription", "Title", "UserId" },
                values: new object[] { 1, "JOB111", new DateTime(2023, 1, 22, 21, 32, 11, 680, DateTimeKind.Local).AddTicks(1661), "BCA", "Software Engineer", "DOT NET", 1 });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCode", "LastApplyDate", "MinimumQualification", "SortDescription", "Title", "UserId" },
                values: new object[] { 2, "JOB112", new DateTime(2023, 1, 22, 21, 32, 11, 684, DateTimeKind.Local).AddTicks(6739), "BCA", "Software Engineer", "PHP", 1 });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "JobCode", "LastApplyDate", "MinimumQualification", "SortDescription", "Title", "UserId" },
                values: new object[] { 3, "JOB113", new DateTime(2023, 1, 22, 21, 32, 11, 684, DateTimeKind.Local).AddTicks(6916), "BCA", "Software Engineer", "Tech Lead", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
