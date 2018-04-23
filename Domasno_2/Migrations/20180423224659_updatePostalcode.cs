using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Domasno_2.Migrations
{
    public partial class updatePostalcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
