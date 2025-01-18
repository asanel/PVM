using Microsoft.EntityFrameworkCore;
using PVM.Client.Service.Repository;
using PVM.Data;
using PVM.Models;
using PVM.Shared.DTOs;
using System.Diagnostics.Metrics;

namespace PVM.Service.Repository
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ApplicationDbContext context;
		public AccountRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<Address> AddAddressAsync(Address address)
		{
			if (address == null) { return null; }

			var newAddress = context.Addresses.Add(address).Entity;
			await context.SaveChangesAsync();

			return newAddress;
		}

		public async Task<Employee> AddEmployeeAsync(Employee employee)
		{
			if (employee == null) { return null; }

			var newEmployee = context.Employees.Add(employee).Entity;
			await context.SaveChangesAsync();

			return newEmployee;
		}

		public async Task<Employee> GetEmployeeByIdAsync(int id)
		{
			var singleEmployee = await context.Employees
								.Include(e => e.Department)
								.Include(e => e.Address)
								.FirstOrDefaultAsync(x => x.Id == id);
			if (singleEmployee == null) return null;
			return singleEmployee;
		}

		public async Task<Employee> UpdateEmployeeAsync(EmployeeDto employee)
		{
			Employee employeeModel = new Employee();

			if (employee == null) 
			{ return null; }
			else
			{
				employeeModel.Id = employee.Id;
				employeeModel.AddressId = employee.AddressId;
				employeeModel.EmailAddress = employee.EmailAddress;
				employeeModel.DateOfBirth = employee.DateOfBirth;
				employeeModel.Firstname = employee.Firstname;
				employeeModel.Lastname = employee.Lastname;
				employeeModel.IsManager = employee.IsManager;
				employeeModel.MaritalStatus = employee.MaritalStatus;
				employeeModel.Position = employee.Position;
				employeeModel.DepartmentId = employee.DepartmentId;
				employeeModel.TaxId = employee.TaxId;
				employeeModel.PhoneNumber = employee.PhoneNumber;
			}
			

			var updatedEmployee = context.Employees
				.Update(employeeModel).Entity;
			await context.SaveChangesAsync();

			return updatedEmployee;
		}

		public async Task<List<Employee>> GetAllEmployeesAsync()
		{
			var employees = await context.Employees.ToListAsync();
			return employees;
		}

		public async Task<Address> UpdateAddressAsync(Address address)
		{
			var newAddress = context.Addresses.Update(address).Entity;
			await context.SaveChangesAsync();
			return newAddress;
		}

		public async Task<Employee> GetEmployeeByUserIdAsync(string userId)
		{
			var singleEmployee = await context.Employees
							.Include(e => e.Department)
							.Include(e => e.Address)
							.FirstOrDefaultAsync(e => e.ApplicationUserId == userId);
			if (singleEmployee == null) return null;
			return singleEmployee;
		}

		public async Task<Employee> GetManagerByDepartmentIdAsync(int departmentId)
		{
			var singleEmployee = await context.Employees
							.Include(e => e.Address)
							.FirstOrDefaultAsync(e => e.IsManager == true && e.DepartmentId == departmentId);
			if (singleEmployee == null) return null;
			return singleEmployee;
		}
	}
}
