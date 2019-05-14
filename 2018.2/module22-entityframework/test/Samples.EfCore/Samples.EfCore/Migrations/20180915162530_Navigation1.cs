using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class Navigation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "FK_StudentGroup",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
