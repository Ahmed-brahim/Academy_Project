using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2_MVC_Task.Migrations
{
    /// <inheritdoc />
    public partial class makeAllNoActionOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_Dept_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_Dept_id",
                table: "Trainees");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_Dept_id",
                table: "Instructors",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors",
                column: "Crs_id",
                principalTable: "courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_Dept_id",
                table: "Trainees",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_Dept_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_Dept_id",
                table: "Trainees");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Departments_Dept_id",
                table: "courses",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_Dept_id",
                table: "Instructors",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors",
                column: "Crs_id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_Dept_id",
                table: "Trainees",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
