using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2_MVC_Task.Migrations
{
    /// <inheritdoc />
    public partial class setNullondelete : Migration
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
                onDelete: ReferentialAction.SetNull);
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
                principalColumn: "Id");
        }
    }
}
