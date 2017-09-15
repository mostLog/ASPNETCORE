using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace L.EntityFramework.Migrations
{
    public partial class _2017915927 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Duration",
                table: "T_Log",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Duration",
                table: "T_Log",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
