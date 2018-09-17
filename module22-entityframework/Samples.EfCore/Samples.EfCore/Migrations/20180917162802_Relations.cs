using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BarId",
                table: "Students",
                column: "BarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Bar_BarId",
                table: "Students",
                column: "BarId",
                principalTable: "Bar",
                principalColumn: "BarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Bar_BarId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BarId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BarId",
                table: "Students");
        }
    }
}
