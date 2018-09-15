using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class Navigation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_FK_StudentGroup",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FK_StudentGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FK_StudentGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Group_Id",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Group_Id",
                table: "Students",
                column: "Group_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_Group_Id",
                table: "Students",
                column: "Group_Id",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_Group_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Group_Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Group_Id",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "FK_StudentGroup",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FK_StudentGroup",
                table: "Students",
                column: "FK_StudentGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_FK_StudentGroup",
                table: "Students",
                column: "FK_StudentGroup",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
