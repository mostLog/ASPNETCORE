using Microsoft.EntityFrameworkCore.Migrations;

namespace L.EntityFramework.Migrations
{
    public partial class _20179121127 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "T_SpiderTask");

            migrationBuilder.AddColumn<int>(
                name: "AcquisitionInterval",
                table: "T_SpiderTask",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcquisitionInterval",
                table: "T_SpiderTask");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "T_SpiderTask",
                nullable: false,
                defaultValue: 0);
        }
    }
}