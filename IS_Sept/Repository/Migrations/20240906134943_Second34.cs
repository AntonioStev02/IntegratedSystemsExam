using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Second34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntitys_BaseEntitys_CourseId",
                table: "BaseEntitys");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntitys_BaseEntitys_SemesterId",
                table: "BaseEntitys");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntitys_BaseEntitys_StudentId",
                table: "BaseEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntitys",
                table: "BaseEntitys");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntitys_CourseId",
                table: "BaseEntitys");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntitys_SemesterId",
                table: "BaseEntitys");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntitys_StudentId",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "AavailableSlots",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "SemesterCode",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "SemesterName",
                table: "BaseEntitys");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "BaseEntitys");

            migrationBuilder.RenameTable(
                name: "BaseEntitys",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AavailableSlots = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentOnCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOnCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentOnCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOnCourses_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOnCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentOnCourses_CourseId",
                table: "StudentOnCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOnCourses_SemesterId",
                table: "StudentOnCourses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOnCourses_StudentId",
                table: "StudentOnCourses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentOnCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "BaseEntitys");

            migrationBuilder.AddColumn<int>(
                name: "AavailableSlots",
                table: "BaseEntitys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "BaseEntitys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "BaseEntitys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "BaseEntitys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntitys",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SemesterCode",
                table: "BaseEntitys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SemesterId",
                table: "BaseEntitys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SemesterName",
                table: "BaseEntitys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "BaseEntitys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntitys",
                table: "BaseEntitys",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntitys_CourseId",
                table: "BaseEntitys",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntitys_SemesterId",
                table: "BaseEntitys",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntitys_StudentId",
                table: "BaseEntitys",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntitys_BaseEntitys_CourseId",
                table: "BaseEntitys",
                column: "CourseId",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntitys_BaseEntitys_SemesterId",
                table: "BaseEntitys",
                column: "SemesterId",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntitys_BaseEntitys_StudentId",
                table: "BaseEntitys",
                column: "StudentId",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
