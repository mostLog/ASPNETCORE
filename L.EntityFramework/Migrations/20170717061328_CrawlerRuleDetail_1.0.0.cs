using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace L.EntityFramework.Migrations
{
    public partial class CrawlerRuleDetail_100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CrawlerRuleDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnName = table.Column<string>(nullable: true),
                    ColumnRule = table.Column<string>(nullable: true),
                    CrawlerRuleId = table.Column<int>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreatePerson = table.Column<string>(nullable: true),
                    OperaterDateTime = table.Column<DateTime>(nullable: true),
                    OperaterPerson = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CrawlerRuleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_CrawlerRuleDetail_T_CrawlerRule_CrawlerRuleId",
                        column: x => x.CrawlerRuleId,
                        principalTable: "T_CrawlerRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CrawlerRuleDetail_CrawlerRuleId",
                table: "T_CrawlerRuleDetail",
                column: "CrawlerRuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CrawlerRuleDetail");
        }
    }
}