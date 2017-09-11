using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace L.EntityFramework.Migrations
{
    public partial class SpiderTask101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpenTime",
                table: "T_SpiderTask");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "T_SpiderTask");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurrent",
                table: "T_SpiderTask",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecurrentDateTime",
                table: "T_SpiderTask",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecurrent",
                table: "T_SpiderTask");

            migrationBuilder.DropColumn(
                name: "RecurrentDateTime",
                table: "T_SpiderTask");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpenTime",
                table: "T_SpiderTask",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenTime",
                table: "T_SpiderTask",
                nullable: true);
        }
    }
}
