using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Domasno_2.Migrations
{
    public partial class FKTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleID",
                table: "Publisher",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_TitleID",
                table: "Publisher",
                column: "TitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Publisher_Title_TitleID",
                table: "Publisher",
                column: "TitleID",
                principalTable: "Title",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publisher_Title_TitleID",
                table: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Publisher_TitleID",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "TitleID",
                table: "Publisher");
        }
    }
}
