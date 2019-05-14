using Microsoft.EntityFrameworkCore.Migrations;

namespace Samples.EfCore.Migrations
{
    public partial class NavigationFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LegalEntityName",
                table: "University",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalEntityRegistration",
                table: "University",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniversityGovNum",
                table: "Group",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_University_LegalEntityName_LegalEntityRegistration",
                table: "University",
                columns: new[] { "LegalEntityName", "LegalEntityRegistration" });

            migrationBuilder.CreateIndex(
                name: "IX_Group_UniversityGovNum",
                table: "Group",
                column: "UniversityGovNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_University_UniversityGovNum",
                table: "Group",
                column: "UniversityGovNum",
                principalTable: "University",
                principalColumn: "GovNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_University_LegalEntity_LegalEntityName_LegalEntityRegistrat~",
                table: "University",
                columns: new[] { "LegalEntityName", "LegalEntityRegistration" },
                principalTable: "LegalEntity",
                principalColumns: new[] { "Name", "Registration" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_University_UniversityGovNum",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_University_LegalEntity_LegalEntityName_LegalEntityRegistrat~",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_University_LegalEntityName_LegalEntityRegistration",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_Group_UniversityGovNum",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "LegalEntityName",
                table: "University");

            migrationBuilder.DropColumn(
                name: "LegalEntityRegistration",
                table: "University");

            migrationBuilder.DropColumn(
                name: "UniversityGovNum",
                table: "Group");
        }
    }
}
