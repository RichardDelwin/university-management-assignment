using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class RemovedStudentFieldfromCollege : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges");


            migrationBuilder.CreateIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges",
                column: "StudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges");

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeId",
                table: "Students",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Colleges_CollegeId",
                table: "Students",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
