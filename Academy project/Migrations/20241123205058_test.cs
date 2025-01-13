using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2_MVC_Task.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.CreateTable(
               name: "CrsResults",
               columns: table => new
               {
                   Trainee_Id = table.Column<int>(type: "int", nullable: false),
                   Course_Id = table.Column<int>(type: "int", nullable: false),
                   Degree = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_CrsResults", x => new { x.Trainee_Id, x.Course_Id });
                   table.ForeignKey(
                       name: "FK_CrsResults_Trainees_Trainee_Id",
                       column: x => x.Trainee_Id,
                       principalTable: "Trainees",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_CrsResults_courses_Course_Id",
                       column: x => x.Course_Id,
                       principalTable: "courses",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });


            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_Course_Id",
                table: "CrsResults",
                column: "Course_Id");

           


        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrsResults");
        }
    }
}
