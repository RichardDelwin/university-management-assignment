using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class manytomanyforStudentAndstcoursescollege : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseColleges_Students_StudentId",
                table: "StudentCourseColleges");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseColleges_StudentId",
                table: "StudentCourseColleges");

            migrationBuilder.CreateTable(
                name: "StudentStudentCourseCollege",
                columns: table => new
                {
                    StudentCourseAndCollegesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudentCourseCollege", x => new { x.StudentCourseAndCollegesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentStudentCourseCollege_StudentCourseColleges_StudentCourseAndCollegesId",
                        column: x => x.StudentCourseAndCollegesId,
                        principalTable: "StudentCourseColleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudentCourseCollege_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentCourseCollege_StudentsId",
                table: "StudentStudentCourseCollege",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStudentCourseCollege");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseColleges_StudentId",
                table: "StudentCourseColleges",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseColleges_Students_StudentId",
                table: "StudentCourseColleges",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
