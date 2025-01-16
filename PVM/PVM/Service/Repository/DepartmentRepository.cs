using Microsoft.EntityFrameworkCore;
using PVM.Client.Service.Repository;
using PVM.Data;
using PVM.Models;

namespace PVM.Service.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly ApplicationDbContext context;
		public DepartmentRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public async Task<Department> AddDepartmentAsync(Department department)
		{
			if (department == null) { return null; }

			var newDepartment = context.Departments.Add(department).Entity;
			await this.context.SaveChangesAsync();

			return newDepartment;
		}

		public async Task<List<Department>> GetAllDepartmentsAsync()
		{
			var departments = await this.context.Departments.ToListAsync();
			return departments;
		}
	}
}
