using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Domasno_2.Migrations
{
    public partial class TitleCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Title",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Title_CustomerID",
                table: "Title",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Title_Customer_CustomerID",
                table: "Title",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Title_Customer_CustomerID",
                table: "Title");

            migrationBuilder.DropIndex(
                name: "IX_Title_CustomerID",
                table: "Title");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Title");
        }
    }
}
