using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Samples.EfCore.Migrations
{
    public partial class NavigationManyToMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_University_LegalEntity_LegalEntityName_LegalEntityRegistrat~",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_University_LegalEntityName_LegalEntityRegistration",
                table: "University");

            migrationBuilder.DropColumn(
                name: "LegalEntityName",
                table: "University");

            migrationBuilder.DropColumn(
                name: "LegalEntityRegistration",
                table: "University");

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonTeacher",
                columns: table => new
                {
                    LessonId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTeacher", x => new { x.LessonId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_LessonTeacher_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonTeacher_TeacherId",
                table: "LessonTeacher",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTeacher");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.AddColumn<string>(
                name: "LegalEntityName",
                table: "University",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalEntityRegistration",
                table: "University",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_University_LegalEntityName_LegalEntityRegistration",
                table: "University",
                columns: new[] { "LegalEntityName", "LegalEntityRegistration" });

            migrationBuilder.AddForeignKey(
                name: "FK_University_LegalEntity_LegalEntityName_LegalEntityRegistrat~",
                table: "University",
                columns: new[] { "LegalEntityName", "LegalEntityRegistration" },
                principalTable: "LegalEntity",
                principalColumns: new[] { "Name", "Registration" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
