using Microsoft.EntityFrameworkCore.Migrations;

namespace Red_Social.Model.Migrations
{
    public partial class addingNewPropertyEnrollInTableTeachers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTeachers",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quotaTeachers",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTeachers",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "quotaTeachers",
                table: "Courses");
        }
    }
}
