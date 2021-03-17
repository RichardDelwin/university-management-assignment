using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AllowednullablesinStudentCollegeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentColleges_Colleges_CollegeId",
                table: "StudentColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentColleges_Students_StudentId",
                table: "StudentColleges");

            migrationBuilder.DropIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentColleges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "StudentColleges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentColleges_Colleges_CollegeId",
                table: "StudentColleges",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentColleges_Students_StudentId",
                table: "StudentColleges",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentColleges_Colleges_CollegeId",
                table: "StudentColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentColleges_Students_StudentId",
                table: "StudentColleges");

            migrationBuilder.DropIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentColleges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "StudentColleges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentColleges_StudentId",
                table: "StudentColleges",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentColleges_Colleges_CollegeId",
                table: "StudentColleges",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentColleges_Students_StudentId",
                table: "StudentColleges",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
