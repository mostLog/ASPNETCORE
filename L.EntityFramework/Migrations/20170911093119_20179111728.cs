using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace L.EntityFramework.Migrations
{
    public partial class _20179111728 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "T_Img");

            migrationBuilder.AddColumn<string>(
                name: "Introduce",
                table: "T_Img",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T_ImageInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    ImgId = table.Column<int>(type: "int", nullable: true),
                    OperaterDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperaterPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ImageInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ImageInfo_T_Img_ImgId",
                        column: x => x.ImgId,
                        principalTable: "T_Img",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ImageInfo_ImgId",
                table: "T_ImageInfo",
                column: "ImgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ImageInfo");

            migrationBuilder.DropColumn(
                name: "Introduce",
                table: "T_Img");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "T_Img",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}