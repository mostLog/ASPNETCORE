using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace L.EntityFramework.Migrations
{
    public partial class updateNotice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Registrants",
                table: "T_Notice",
                newName: "Registrant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Registrant",
                table: "T_Notice",
                newName: "Registrants");
        }
    }
}
