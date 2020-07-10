using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassroomSE.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Accounts_AccountID",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Assignments_AssignmentID",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                table: "Grade");

            migrationBuilder.RenameTable(
                name: "Grade",
                newName: "Grades");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_AssignmentID",
                table: "Grades",
                newName: "IX_Grades_AssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_AccountID",
                table: "Grades",
                newName: "IX_Grades_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "GradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Accounts_AccountID",
                table: "Grades",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Assignments_AssignmentID",
                table: "Grades",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Accounts_AccountID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Assignments_AssignmentID",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grade");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_AssignmentID",
                table: "Grade",
                newName: "IX_Grade_AssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_AccountID",
                table: "Grade",
                newName: "IX_Grade_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                table: "Grade",
                column: "GradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Accounts_AccountID",
                table: "Grade",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Assignments_AssignmentID",
                table: "Grade",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
