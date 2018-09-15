using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class AddRequirements2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Lesson",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Lesson",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
