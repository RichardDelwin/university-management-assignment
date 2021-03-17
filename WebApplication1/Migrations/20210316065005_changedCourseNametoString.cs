using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class changedCourseNametoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "courseName",
                table: "Courses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "courseName",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Courses",
                type: "int",
                maxLength: 32,
                nullable: false,
                defaultValue: 0);
        }
    }
}
