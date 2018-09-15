using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Samples.EfCore.Migrations
{
    public partial class Navigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewGroupId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_InterviewGroupId",
                table: "Students",
                column: "InterviewGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_InterviewGroupId",
                table: "Students",
                column: "InterviewGroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_InterviewGroupId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_InterviewGroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "InterviewGroupId",
                table: "Students");
        }
    }
}
