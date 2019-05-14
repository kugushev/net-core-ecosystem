using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_University_UniversityGovNum",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityGovNum",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "UniversityGovNum",
                table: "Students",
                newName: "GovNum");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GovNum",
                table: "Students",
                column: "GovNum",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_University_GovNum",
                table: "Students",
                column: "GovNum",
                principalTable: "University",
                principalColumn: "GovNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_University_GovNum",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GovNum",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Name",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GovNum",
                table: "Students",
                newName: "UniversityGovNum");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityGovNum",
                table: "Students",
                column: "UniversityGovNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_University_UniversityGovNum",
                table: "Students",
                column: "UniversityGovNum",
                principalTable: "University",
                principalColumn: "GovNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
