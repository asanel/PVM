using Microsoft.AspNetCore.Identity;
using PVM.Data;
using PVM.Models;

namespace PVM.Service
{
	public class UserService
	{
		//private readonly UserManager<ApplicationUser> _userManager;
		//private readonly ApplicationDbContext _context;

		//public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
		//{
		//	_userManager = userManager;
		//	_context = context;
		//}

		//public async Task CreateUserWithEmployee(string username, string email, string password, string firstname, string lastname, string department)
		//{
		//	var user = new ApplicationUser
		//	{
		//		UserName = username,
		//		Email = email,
		//	};

		//	var result = await _userManager.CreateAsync(user, password);

		//	if (result.Succeeded)
		//	{
		//		var employee = new Employee
		//		{
		//			FullName = fullName,
		//			Department = department,
		//			ApplicationUserId = user.Id // Verknüpfung mit dem Benutzer
		//		};

		//		_context.Employees.Add(employee);
		//		await _context.SaveChangesAsync();
		//	}
		//	else
		//	{
		//		throw new Exception("Benutzer konnte nicht erstellt werden.");
		//	}
		//}
	}
}
