using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace L.EntityFramework.Migrations
{
    public partial class NovelType100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NovelTypeId",
                table: "T_Novel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NovelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperaterDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperaterPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovelType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Novel_NovelTypeId",
                table: "T_Novel",
                column: "NovelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Novel_NovelType_NovelTypeId",
                table: "T_Novel",
                column: "NovelTypeId",
                principalTable: "NovelType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Novel_NovelType_NovelTypeId",
                table: "T_Novel");

            migrationBuilder.DropTable(
                name: "NovelType");

            migrationBuilder.DropIndex(
                name: "IX_T_Novel_NovelTypeId",
                table: "T_Novel");

            migrationBuilder.DropColumn(
                name: "NovelTypeId",
                table: "T_Novel");
        }
    }
}