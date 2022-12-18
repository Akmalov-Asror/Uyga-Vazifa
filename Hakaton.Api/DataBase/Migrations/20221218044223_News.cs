using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakatonApi.Database.Migrations
{
    public partial class News : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Tasks_TaskId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "HomeWorks");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CourseId",
                table: "HomeWorks",
                newName: "IX_HomeWorks_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeWorks",
                table: "HomeWorks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Courses_CourseId",
                table: "HomeWorks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_HomeWorks_TaskId",
                table: "Results",
                column: "TaskId",
                principalTable: "HomeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Courses_CourseId",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_HomeWorks_TaskId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeWorks",
                table: "HomeWorks");

            migrationBuilder.RenameTable(
                name: "HomeWorks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_HomeWorks_CourseId",
                table: "Tasks",
                newName: "IX_Tasks_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Tasks_TaskId",
                table: "Results",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
