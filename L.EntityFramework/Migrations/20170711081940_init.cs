using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace L.EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Notice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsTop = table.Column<bool>(nullable: true),
                    Registrant = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Notice", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Notice");
        }
    }
}