using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace L.EntityFramework.Migrations
{
    public partial class _20179201735 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastVerifyDateTime",
                table: "T_Proxy",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastVerifyDateTime",
                table: "T_Proxy",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
