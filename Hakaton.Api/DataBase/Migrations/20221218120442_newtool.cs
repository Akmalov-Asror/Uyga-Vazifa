using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakatonApi.Database.Migrations
{
    public partial class newtool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Courses_CourseId",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_AspNetUsers_UserId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_HomeWorks_TaskId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Result",
                newName: "HomeWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_UserId",
                table: "Result",
                newName: "IX_Result_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_TaskId",
                table: "Result",
                newName: "IX_Result_HomeWorkId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "HomeWorks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedTime",
                table: "Result",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Result",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c0030910-9390-4c9b-b370-37790d5764a9"), 0, null, "1137c536-f26c-4eb9-a85d-b4f4edf35ec9", null, false, "Abdurauf", "Makhammatov", false, null, null, null, null, null, null, false, null, false, "Abdurauf" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Key" },
                values: new object[] { new Guid("f2aab6de-b41e-41b8-b9d0-4b18f22497f2"), "firstRoom", new Guid("acf22b55-cd4c-457a-9125-f108f71202fe") });

            migrationBuilder.InsertData(
                table: "CourseUsers",
                columns: new[] { "Id", "CourseId", "IsAdmin", "UserId" },
                values: new object[] { new Guid("53634eaf-26e7-4dfd-adc9-79651d29bec4"), new Guid("f2aab6de-b41e-41b8-b9d0-4b18f22497f2"), true, new Guid("c0030910-9390-4c9b-b370-37790d5764a9") });

            migrationBuilder.InsertData(
                table: "HomeWorks",
                columns: new[] { "Id", "CourseId", "CreateDate", "EndDate", "FilePath", "MaxScore", "StartDate", "Status", "TaskDescription", "TaskName" },
                values: new object[,]
                {
                    { new Guid("1b5dfbfc-76cd-4c46-8206-040c0383c2ec"), new Guid("f2aab6de-b41e-41b8-b9d0-4b18f22497f2"), null, null, null, 100, null, 0, "bahonalar o`tmaydi, hatto spravka ham", "50 ta listga referat yozib keling" },
                    { new Guid("a057fc39-c0ba-4be1-b21b-404935dfc273"), new Guid("f2aab6de-b41e-41b8-b9d0-4b18f22497f2"), null, null, null, 100, null, 0, "bahonalar o`tmaydi, hatto spravka ham", "50 ta listga referat yozib keling" }
                });

            migrationBuilder.InsertData(
                table: "Result",
                columns: new[] { "Id", "CompletedTime", "FilePath", "HomeWorkId", "ResultStatus", "Score", "StudentComment", "TeacherComment", "UserId" },
                values: new object[,]
                {
                    { new Guid("a4a08dab-849b-40bd-b31b-fa1f1251f4ba"), null, null, new Guid("1b5dfbfc-76cd-4c46-8206-040c0383c2ec"), 3, 56, "Cut the bullshit", "Men yorvorganman", new Guid("c0030910-9390-4c9b-b370-37790d5764a9") },
                    { new Guid("e7380720-03d0-4e00-b52d-01f9236266fc"), null, null, new Guid("a057fc39-c0ba-4be1-b21b-404935dfc273"), 2, 96, "In shaa Allah", "WOW", new Guid("c0030910-9390-4c9b-b370-37790d5764a9") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Courses_CourseId",
                table: "HomeWorks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_AspNetUsers_UserId",
                table: "Result",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_HomeWorks_HomeWorkId",
                table: "Result",
                column: "HomeWorkId",
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
                name: "FK_Result_AspNetUsers_UserId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_HomeWorks_HomeWorkId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.DeleteData(
                table: "CourseUsers",
                keyColumn: "Id",
                keyValue: new Guid("53634eaf-26e7-4dfd-adc9-79651d29bec4"));

            migrationBuilder.DeleteData(
                table: "Result",
                keyColumn: "Id",
                keyValue: new Guid("a4a08dab-849b-40bd-b31b-fa1f1251f4ba"));

            migrationBuilder.DeleteData(
                table: "Result",
                keyColumn: "Id",
                keyValue: new Guid("e7380720-03d0-4e00-b52d-01f9236266fc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0030910-9390-4c9b-b370-37790d5764a9"));

            migrationBuilder.DeleteData(
                table: "HomeWorks",
                keyColumn: "Id",
                keyValue: new Guid("1b5dfbfc-76cd-4c46-8206-040c0383c2ec"));

            migrationBuilder.DeleteData(
                table: "HomeWorks",
                keyColumn: "Id",
                keyValue: new Guid("a057fc39-c0ba-4be1-b21b-404935dfc273"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f2aab6de-b41e-41b8-b9d0-4b18f22497f2"));

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Result");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Results");

            migrationBuilder.RenameColumn(
                name: "HomeWorkId",
                table: "Results",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Result_UserId",
                table: "Results",
                newName: "IX_Results_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Result_HomeWorkId",
                table: "Results",
                newName: "IX_Results_TaskId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "HomeWorks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedTime",
                table: "Results",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Courses_CourseId",
                table: "HomeWorks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_AspNetUsers_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_HomeWorks_TaskId",
                table: "Results",
                column: "TaskId",
                principalTable: "HomeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
