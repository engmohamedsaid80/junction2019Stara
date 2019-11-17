using Microsoft.EntityFrameworkCore.Migrations;

namespace StaraDomainModels.Migrations
{
    public partial class Taskpriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "priority",
                table: "Tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priority",
                table: "Tasks");
        }
    }
}
