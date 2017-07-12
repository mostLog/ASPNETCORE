using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace L.EntityFramework.Migrations
{
    public partial class CrawlerRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrawlerRuleId",
                table: "T_SpiderTask",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrawlerType",
                table: "T_SpiderTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpenTime",
                table: "T_SpiderTask",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenTime",
                table: "T_SpiderTask",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T_CrawlerRule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreatePerson = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OperaterDateTime = table.Column<DateTime>(nullable: true),
                    OperaterPerson = table.Column<string>(nullable: true),
                    RuleContent = table.Column<string>(nullable: true),
                    RuleType = table.Column<int>(nullable: false),
                    SpiderTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CrawlerRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_CrawlerRule_T_SpiderTask_SpiderTaskId",
                        column: x => x.SpiderTaskId,
                        principalTable: "T_SpiderTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_SpiderTask_CrawlerRuleId",
                table: "T_SpiderTask",
                column: "CrawlerRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CrawlerRule_SpiderTaskId",
                table: "T_CrawlerRule",
                column: "SpiderTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_SpiderTask_T_CrawlerRule_CrawlerRuleId",
                table: "T_SpiderTask",
                column: "CrawlerRuleId",
                principalTable: "T_CrawlerRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_SpiderTask_T_CrawlerRule_CrawlerRuleId",
                table: "T_SpiderTask");

            migrationBuilder.DropTable(
                name: "T_CrawlerRule");

            migrationBuilder.DropIndex(
                name: "IX_T_SpiderTask_CrawlerRuleId",
                table: "T_SpiderTask");

            migrationBuilder.DropColumn(
                name: "CrawlerRuleId",
                table: "T_SpiderTask");

            migrationBuilder.DropColumn(
                name: "CrawlerType",
                table: "T_SpiderTask");

            migrationBuilder.DropColumn(
                name: "IsOpenTime",
                table: "T_SpiderTask");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "T_SpiderTask");
        }
    }
}
