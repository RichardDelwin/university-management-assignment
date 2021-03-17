using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class fkOfStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseColleges_Colleges_CollegeId",
                table: "StudentCourseColleges");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseColleges_CollegeId",
                table: "StudentCourseColleges");

            migrationBuilder.AddColumn<int>(
                name: "CollegesCollegeId",
                table: "StudentCourseColleges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollegesCourseId",
                table: "StudentCourseColleges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseColleges_CollegesCollegeId_CollegesCourseId",
                table: "StudentCourseColleges",
                columns: new[] { "CollegesCollegeId", "CollegesCourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseColleges_CollegeCourses_CollegesCollegeId_CollegesCourseId",
                table: "StudentCourseColleges",
                columns: new[] { "CollegesCollegeId", "CollegesCourseId" },
                principalTable: "CollegeCourses",
                principalColumns: new[] { "CollegeId", "CourseId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseColleges_CollegeCourses_CollegesCollegeId_CollegesCourseId",
                table: "StudentCourseColleges");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseColleges_CollegesCollegeId_CollegesCourseId",
                table: "StudentCourseColleges");

            migrationBuilder.DropColumn(
                name: "CollegesCollegeId",
                table: "StudentCourseColleges");

            migrationBuilder.DropColumn(
                name: "CollegesCourseId",
                table: "StudentCourseColleges");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseColleges_CollegeId",
                table: "StudentCourseColleges",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseColleges_Colleges_CollegeId",
                table: "StudentCourseColleges",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
