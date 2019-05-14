using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class Renamings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniversityDegree",
                table: "Students",
                newName: "UniDegree");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "FullName");

            migrationBuilder.AddColumn<Guid>(
                name: "SuperId",
                table: "LegalEntity",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperId",
                table: "LegalEntity");

            migrationBuilder.RenameColumn(
                name: "UniDegree",
                table: "Students",
                newName: "UniversityDegree");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Students",
                newName: "Name");
        }
    }
}
