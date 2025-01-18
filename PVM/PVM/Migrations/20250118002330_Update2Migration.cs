using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVM.Migrations
{
    /// <inheritdoc />
    public partial class Update2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceEntries_Employees_EmployeeId",
                table: "AbsenceEntries");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceEntries_EmployeeId",
                table: "AbsenceEntries");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AbsenceEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AbsenceEntries");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceEntries_EmployeeId",
                table: "AbsenceEntries",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceEntries_Employees_EmployeeId",
                table: "AbsenceEntries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
