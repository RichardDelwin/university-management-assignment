using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class attemptToaddCollegeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeCourse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollegeCourse",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    OfferingCollegesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeCourse", x => new { x.CoursesId, x.OfferingCollegesId });
                    table.ForeignKey(
                        name: "FK_CollegeCourse_Colleges_OfferingCollegesId",
                        column: x => x.OfferingCollegesId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollegeCourse_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollegeCourse_OfferingCollegesId",
                table: "CollegeCourse",
                column: "OfferingCollegesId");
        }
    }
}
