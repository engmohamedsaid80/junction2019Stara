using Microsoft.EntityFrameworkCore.Migrations;

namespace StaraDomainModels.Migrations
{
    public partial class TaskUpdatenewid1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "task_Id",
                table: "TaskUpdates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "worker_id",
                table: "TaskUpdates",
                nullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "task_Id",
                table: "TaskUpdates");

            migrationBuilder.DropColumn(
                name: "worker_id",
                table: "TaskUpdates");

           
        }
    }
}
