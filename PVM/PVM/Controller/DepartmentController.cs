using Microsoft.AspNetCore.Mvc;
using PVM.Client.Service.Repository;
using PVM.Data;
using PVM.Models;

namespace PVM.Controller
{
	[Route("api/[controller]")]
	[ApiController]

	public class DepartmentController : ControllerBase
	{
		IDepartmentRepository departmentRespoitory;
		ApplicationDbContext applicationDbContext;
		public DepartmentController(IDepartmentRepository departmentRepository, ApplicationDbContext applicationDbContext)
		{
			this.departmentRespoitory = departmentRepository;
			this.applicationDbContext = applicationDbContext;
		}
		[HttpGet("All-Departments")]
		public async Task<ActionResult<List<Department>>> GetAllDepartmentsAsync()
		{
			var departments =  await this.departmentRespoitory.GetAllDepartmentsAsync();
			return Ok(departments);
		}

		[HttpPost("Add-Department")]
		public async Task<ActionResult<Department>> AddDepartmentAsync(Department department)
		{
			if (string.IsNullOrWhiteSpace(department.Name))
			{
				return BadRequest("Department name cannot be null or empty.");
			}
			var newDepartment = await this.departmentRespoitory.AddDepartmentAsync(department);
			return Ok(newDepartment);
		}

	}
}
