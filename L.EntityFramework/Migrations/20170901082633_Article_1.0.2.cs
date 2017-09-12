using Microsoft.EntityFrameworkCore.Migrations;

namespace L.EntityFramework.Migrations
{
    public partial class Article_102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Seq",
                table: "T_Article",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seq",
                table: "T_Article");
        }
    }
}