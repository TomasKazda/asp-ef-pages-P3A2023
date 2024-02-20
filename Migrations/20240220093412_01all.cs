using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp_ef_pages.Migrations
{
    /// <inheritdoc />
    public partial class _01all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortName = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MentorId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teachers_Teachers_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentEmail = table.Column<string>(type: "TEXT", nullable: true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubject",
                columns: table => new
                {
                    Classes2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Subjects2Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubject", x => new { x.Classes2Id, x.Subjects2Id });
                    table.ForeignKey(
                        name: "FK_ClassSubject_Classes_Classes2Id",
                        column: x => x.Classes2Id,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubject_Subjects_Subjects2Id",
                        column: x => x.Subjects2Id,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsOnClasses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    LinkId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsOnClasses", x => new { x.ClassId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectsOnClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsOnClasses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsOnClasses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "P3A" },
                    { 2, "P4" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Mathematics", "MAT" },
                    { 2, "English", "ANJ" },
                    { 3, "Web application", "WEB" },
                    { 4, "Multiplatform app", "MPA" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "MentorId", "Name" },
                values: new object[,]
                {
                    { new Guid("17b366f0-a169-4340-bddb-284af3ff6dc6"), null, "Mr. Smith" },
                    { new Guid("e41fb9e4-1d7c-4c5a-a692-248d993c23c8"), null, "Mrs. Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "StudentEmail", "StudentName" },
                values: new object[,]
                {
                    { new Guid("15e78531-25fb-4d3d-af0e-7b09049a8a2c"), 1, null, "Alice" },
                    { new Guid("92ddaf81-1bf7-4168-a649-12480084b09b"), 1, null, "Bob" },
                    { new Guid("973c0e69-0984-4e03-8fa6-ecbc93f78d1e"), 2, null, "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "SubjectsOnClasses",
                columns: new[] { "ClassId", "SubjectId", "LinkId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, 1, new Guid("17b366f0-a169-4340-bddb-284af3ff6dc6") },
                    { 1, 2, 2, new Guid("17b366f0-a169-4340-bddb-284af3ff6dc6") },
                    { 1, 3, 3, new Guid("17b366f0-a169-4340-bddb-284af3ff6dc6") },
                    { 2, 1, 4, new Guid("17b366f0-a169-4340-bddb-284af3ff6dc6") }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "MentorId", "Name" },
                values: new object[] { new Guid("6b7462cb-3869-4199-ae27-10a13eb51728"), new Guid("17b366f0-a169-4340-bddb-284af3ff6dc6"), "Mrs. Newbie" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_Subjects2Id",
                table: "ClassSubject",
                column: "Subjects2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOnClasses_LinkId",
                table: "SubjectsOnClasses",
                column: "LinkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOnClasses_SubjectId",
                table: "SubjectsOnClasses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOnClasses_TeacherId",
                table: "SubjectsOnClasses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_MentorId",
                table: "Teachers",
                column: "MentorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSubject");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectsOnClasses");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
