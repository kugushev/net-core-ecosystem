using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_InterviewGroupId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "InterviewGroupId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_InterviewGroupId",
                table: "Students",
                column: "InterviewGroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_InterviewGroupId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "InterviewGroupId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_InterviewGroupId",
                table: "Students",
                column: "InterviewGroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
