using Microsoft.EntityFrameworkCore.Migrations;

namespace Red_Social.Model.Migrations
{
    public partial class addingNewPropertyNumberOfStudentsInTableCourses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
