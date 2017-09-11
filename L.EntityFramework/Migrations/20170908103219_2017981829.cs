using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace L.EntityFramework.Migrations
{
    public partial class _2017981829 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpenEmail",
                table: "T_Novel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpenEmail",
                table: "T_Novel");
        }
    }
}
