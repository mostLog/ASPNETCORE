using Microsoft.EntityFrameworkCore.Migrations;

namespace L.EntityFramework.Migrations
{
    public partial class SpiderTask103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecurrentCron",
                table: "T_SpiderTask",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecurrentCron",
                table: "T_SpiderTask");
        }
    }
}