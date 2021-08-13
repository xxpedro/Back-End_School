using Microsoft.EntityFrameworkCore.Migrations;

namespace Red_Social.Model.Migrations
{
    public partial class addingNewPropertyNumberOfStudentsInTableCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudents",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "Courses");
        }
    }
}
