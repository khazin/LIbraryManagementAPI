using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIbraryManagementAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "available",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "returnDate",
                table: "Records",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "returnDate",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "available",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
