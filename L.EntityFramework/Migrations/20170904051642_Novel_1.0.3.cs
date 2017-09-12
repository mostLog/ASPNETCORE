using Microsoft.EntityFrameworkCore.Migrations;

namespace L.EntityFramework.Migrations
{
    public partial class Novel_103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRecurrent",
                table: "T_Novel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecurrent",
                table: "T_Novel");
        }
    }
}