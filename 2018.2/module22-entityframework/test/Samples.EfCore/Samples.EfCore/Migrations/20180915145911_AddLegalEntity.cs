using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Samples.EfCore.Migrations
{
    public partial class AddLegalEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_University_UniversityId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_University",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "University");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "GovNum",
                table: "University",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UniversityGovNum",
                table: "Students",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_University",
                table: "University",
                column: "GovNum");

            migrationBuilder.CreateTable(
                name: "LegalEntity",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Registration = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntity", x => new { x.Name, x.Registration });
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_University_UniversityGovNum",
                table: "Students");

            migrationBuilder.DropTable(
                name: "LegalEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_University",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityGovNum",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GovNum",
                table: "University");

            migrationBuilder.DropColumn(
                name: "UniversityGovNum",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "University",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_University",
                table: "University",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityId",
                table: "Students",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_University_UniversityId",
                table: "Students",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
