using Microsoft.EntityFrameworkCore.Migrations;

namespace Red_Social.Model.Migrations
{
    public partial class addingNewPropertyInTableCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quota",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quota",
                table: "Courses");
        }
    }
}
