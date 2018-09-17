using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class Relations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "FavoriteBarId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NegativeBarBarId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FavoriteBarId",
                table: "Students",
                column: "FavoriteBarId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NegativeBarBarId",
                table: "Students",
                column: "NegativeBarBarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Bar_FavoriteBarId",
                table: "Students",
                column: "FavoriteBarId",
                principalTable: "Bar",
                principalColumn: "BarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Bar_NegativeBarBarId",
                table: "Students",
                column: "NegativeBarBarId",
                principalTable: "Bar",
                principalColumn: "BarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Bar_FavoriteBarId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Bar_NegativeBarBarId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FavoriteBarId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NegativeBarBarId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FavoriteBarId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NegativeBarBarId",
                table: "Students");

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
    }
}
