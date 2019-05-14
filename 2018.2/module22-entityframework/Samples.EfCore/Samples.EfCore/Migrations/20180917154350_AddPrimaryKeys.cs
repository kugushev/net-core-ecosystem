using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Samples.EfCore.Migrations
{
    public partial class AddPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniversityGovNum",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bar",
                columns: table => new
                {
                    BarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bar", x => x.BarId);
                });

            migrationBuilder.CreateTable(
                name: "LegalEntity",
                columns: table => new
                {
                    EGRUL = table.Column<string>(nullable: false),
                    INN = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntity", x => new { x.EGRUL, x.INN });
                });

            migrationBuilder.CreateTable(
                name: "Unversity",
                columns: table => new
                {
                    GovNum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unversity", x => x.GovNum);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityGovNum",
                table: "Students",
                column: "UniversityGovNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Unversity_UniversityGovNum",
                table: "Students",
                column: "UniversityGovNum",
                principalTable: "Unversity",
                principalColumn: "GovNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Unversity_UniversityGovNum",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Bar");

            migrationBuilder.DropTable(
                name: "LegalEntity");

            migrationBuilder.DropTable(
                name: "Unversity");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityGovNum",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UniversityGovNum",
                table: "Students");
        }
    }
}
