using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace L.EntityFramework.Migrations
{
    public partial class Novel_101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Novel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperaterDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperaterPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Novel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NovelId = table.Column<int>(type: "int", nullable: true),
                    OperaterDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperaterPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Article_T_Novel_NovelId",
                        column: x => x.NovelId,
                        principalTable: "T_Novel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Article_NovelId",
                table: "T_Article",
                column: "NovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Article");

            migrationBuilder.DropTable(
                name: "T_Novel");
        }
    }
}