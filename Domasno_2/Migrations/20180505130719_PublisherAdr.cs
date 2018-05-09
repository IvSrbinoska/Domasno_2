using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Domasno_2.Migrations
{
    public partial class PublisherAdr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Publisher",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_CustomerID",
                table: "Publisher",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PublisherID",
                table: "Address",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Publisher_PublisherID",
                table: "Address",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publisher_Customer_CustomerID",
                table: "Publisher",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Publisher_PublisherID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Publisher_Customer_CustomerID",
                table: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Publisher_CustomerID",
                table: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Address_PublisherID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Address");
        }
    }
}
