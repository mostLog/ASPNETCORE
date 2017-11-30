using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace L.EntityFramework.Migrations
{
    public partial class _201711281354 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "T_DataTypeClassification");

            migrationBuilder.AddColumn<string>(
                name: "ClassId",
                table: "T_DataTypeClassification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataTypeClassificationId",
                table: "T_DataTypeClassification",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_DataTypeClassification_DataTypeClassificationId",
                table: "T_DataTypeClassification",
                column: "DataTypeClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_DataTypeClassification_T_DataTypeClassification_DataTypeClassificationId",
                table: "T_DataTypeClassification",
                column: "DataTypeClassificationId",
                principalTable: "T_DataTypeClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_DataTypeClassification_T_DataTypeClassification_DataTypeClassificationId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropIndex(
                name: "IX_T_DataTypeClassification_DataTypeClassificationId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropColumn(
                name: "DataTypeClassificationId",
                table: "T_DataTypeClassification");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "T_DataTypeClassification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "T_DataTypeClassification",
                nullable: true);
        }
    }
}
