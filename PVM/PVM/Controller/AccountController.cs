using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PVM.Client.Service.Repository;
using PVM.Models;



namespace PVM.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountRepository repository;

		public AccountController(IAccountRepository repository)
		{
			this.repository = repository;
		}



		[HttpPost("Add-Address")]
		[AllowAnonymous]
		[IgnoreAntiforgeryToken]
		public async Task<ActionResult<Address>> AddAddress(Address address)
		{
			var newAddress = await repository.AddAddressAsync(address);

			return Ok(newAddress);
		}

		[HttpPost("Add-Employee")]
		public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
		{
			var newEmployee = await repository.AddEmployeeAsync(employee);

			return Ok(newEmployee);
		}

		[HttpGet("Get-Single-Employee/{id}")]
		public async Task<ActionResult<Employee>> GetEmployeeById(int id)
		{
			var newEmployee = await repository.GetEmployeeByIdAsync(id);

			return Ok(newEmployee);
		}

		[HttpGet("Get-Single-EmployeeByUserId/{userId}")]
		public async Task<ActionResult<Employee>> GetEmployeeByUserId(string userId)
		{
			var newEmployee = await repository.GetEmployeeByUserIdAsync(userId);

			return Ok(newEmployee);
		}

		[HttpPut("Update-Employee")]
		public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
		{
			var newEmployee = await repository.UpdateEmployeeAsync(employee);

			return Ok(newEmployee);
		}
		[HttpGet("All-Employees")]
		public async Task<ActionResult<List<Employee>>> GetAllEmployees()
		{
			var employees = await repository.GetAllEmployeesAsync();
			return Ok(employees);
		}
		[HttpPatch("Update-Address")]
		public async Task<ActionResult<Address>> UpdateAddress(Address addres)
		{
			var newAddess = await repository.UpdateAddressAsync(addres);
			return Ok(newAddess);
		}




	}
}
