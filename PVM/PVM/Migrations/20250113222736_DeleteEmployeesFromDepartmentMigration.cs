using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVM.Migrations
{
	/// <inheritdoc />
	public partial class DeleteEmployeesFromDepartmentMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Employees_Departments_DepartmentId",
				table: "Employees");

			migrationBuilder.DropTable(
				name: "Manager");

			migrationBuilder.AlterColumn<string>(
				name: "PhoneNumber",
				table: "Employees",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AddForeignKey(
				name: "FK_Employees_Departments_DepartmentId",
				table: "Employees",
				column: "DepartmentId",
				principalTable: "Departments",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Employees_Departments_DepartmentId",
				table: "Employees");

			migrationBuilder.AlterColumn<int>(
				name: "PhoneNumber",
				table: "Employees",
				type: "int",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.CreateTable(
				name: "Manager",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AddressId = table.Column<int>(type: "int", nullable: false),
					ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					DepartmentId = table.Column<int>(type: "int", nullable: false),
					DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
					EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
					MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
					PhoneNumber = table.Column<int>(type: "int", nullable: false),
					Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
					TaxId = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Manager", x => x.Id);
					table.ForeignKey(
						name: "FK_Manager_Addresses_AddressId",
						column: x => x.AddressId,
						principalTable: "Addresses",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Manager_AspNetUsers_ApplicationUserId",
						column: x => x.ApplicationUserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Manager_Departments_DepartmentId",
						column: x => x.DepartmentId,
						principalTable: "Departments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Manager_AddressId",
				table: "Manager",
				column: "AddressId");

			migrationBuilder.CreateIndex(
				name: "IX_Manager_ApplicationUserId",
				table: "Manager",
				column: "ApplicationUserId");

			migrationBuilder.CreateIndex(
				name: "IX_Manager_DepartmentId",
				table: "Manager",
				column: "DepartmentId",
				unique: true);

			migrationBuilder.AddForeignKey(
				name: "FK_Employees_Departments_DepartmentId",
				table: "Employees",
				column: "DepartmentId",
				principalTable: "Departments",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
