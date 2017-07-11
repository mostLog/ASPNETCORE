using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace L.EntityFramework.Migrations
{
    public partial class SpiderTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Registrant",
                table: "T_Notice",
                newName: "OperaterPerson");

            migrationBuilder.RenameColumn(
                name: "AddDate",
                table: "T_Notice",
                newName: "OperaterDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "T_Notice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatePerson",
                table: "T_Notice",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T_SpiderTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreatePerson = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OperaterDateTime = table.Column<DateTime>(nullable: true),
                    OperaterPerson = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SpiderTask", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_SpiderTask");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "T_Notice");

            migrationBuilder.DropColumn(
                name: "CreatePerson",
                table: "T_Notice");

            migrationBuilder.RenameColumn(
                name: "OperaterPerson",
                table: "T_Notice",
                newName: "Registrant");

            migrationBuilder.RenameColumn(
                name: "OperaterDateTime",
                table: "T_Notice",
                newName: "AddDate");
        }
    }
}
