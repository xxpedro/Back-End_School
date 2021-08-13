using Microsoft.EntityFrameworkCore.Migrations;

namespace Red_Social.Model.Migrations
{
    public partial class addingNewPropertyEnrollInTableTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "enrollment",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enrollment",
                table: "Teachers");
        }
    }
}
