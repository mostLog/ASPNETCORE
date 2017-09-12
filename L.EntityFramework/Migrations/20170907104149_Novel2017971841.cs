using Microsoft.EntityFrameworkCore.Migrations;

namespace L.EntityFramework.Migrations
{
    public partial class Novel2017971841 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "T_Novel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "T_Novel");
        }
    }
}