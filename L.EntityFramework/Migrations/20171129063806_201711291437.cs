using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace L.EntityFramework.Migrations
{
    public partial class _201711291437 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_DataTypeClassification_T_DataTypeClassification_DataTypeClassificationId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropIndex(
                name: "IX_T_DataTypeClassification_DataTypeClassificationId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropColumn(
                name: "DataTypeClassificationId",
                table: "T_DataTypeClassification");

            migrationBuilder.AlterColumn<int>(
                name: "Seq",
                table: "T_DataTypeClassification",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "T_DataTypeClassification",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_DataTypeClassification_ParentId",
                table: "T_DataTypeClassification",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_DataTypeClassification_T_DataTypeClassification_ParentId",
                table: "T_DataTypeClassification",
                column: "ParentId",
                principalTable: "T_DataTypeClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_DataTypeClassification_T_DataTypeClassification_ParentId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropIndex(
                name: "IX_T_DataTypeClassification_ParentId",
                table: "T_DataTypeClassification");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "T_DataTypeClassification");

            migrationBuilder.AlterColumn<int>(
                name: "Seq",
                table: "T_DataTypeClassification",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataTypeClassificationId",
                table: "T_DataTypeClassification",
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
    }
}
