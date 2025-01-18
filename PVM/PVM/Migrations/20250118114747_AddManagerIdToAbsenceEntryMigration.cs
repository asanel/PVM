using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVM.Migrations
{
    /// <inheritdoc />
    public partial class AddManagerIdToAbsenceEntryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "AbsenceEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "AbsenceEntries");
        }
    }
}
