using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2_MVC_Task.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
