using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class AddIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_FullName",
                table: "Students",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Sex",
                table: "Students",
                column: "Sex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_FullName",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Sex",
                table: "Students");
        }
    }
}
