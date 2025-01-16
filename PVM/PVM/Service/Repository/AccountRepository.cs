using Microsoft.EntityFrameworkCore;
using PVM.Client.Service.Repository;
using PVM.Data;
using PVM.Models;
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
			var singleEmployee = await context.Employees.Where(x => x.Id == id)
								.Include(e => e.Address) // Address einbeziehen
								.Include(e => e.Department)
								.Include(e => e.ApplicationUser)
								.FirstOrDefaultAsync();
			if (singleEmployee == null) return null;
			return singleEmployee;
		}

		public async Task<Employee> UpdateEmployeeAsync(Employee employee)
		{
			if (employee == null) return null;

			var updatedEmployee = context.Employees
				.Update(employee).Entity;
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
								.Include(e => e.Address) // Address einbeziehen
								.Include(e => e.Department)
								.Include(e => e.ApplicationUser)
								.FirstOrDefaultAsync(e => e.ApplicationUserId == userId);
			if (singleEmployee == null) return null;
			return singleEmployee;
		}
	}
}
