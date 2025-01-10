using Microsoft.AspNetCore.Identity;
using PVM.Data;
using PVM.Models;

namespace PVM.Service
{
	public class ManagerServcie
	{
		//	private readonly UserManager<ApplicationUser> _userManager;
		//	private readonly RoleManager<IdentityRole> _roleManager;
		//	private readonly ApplicationDbContext _context;

		//	public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
		//	{
		//		_userManager = userManager;
		//		_roleManager = roleManager;
		//		_context = context;
		//	}

		//	public async Task CreateManagerUser(string username, string email, string password, string department)
		//	{
		//		// Prüfen, ob die Rolle "Manager" existiert
		//		if (!await _roleManager.RoleExistsAsync("Manager"))
		//		{
		//			await _roleManager.CreateAsync(new IdentityRole("Manager"));
		//		}

		//		// Benutzer erstellen
		//		var user = new ApplicationUser
		//		{
		//			UserName = username,
		//			Email = email
		//		};

		//		var result = await _userManager.CreateAsync(user, password);

		//		if (result.Succeeded)
		//		{
		//			// Rolle "Manager" zuweisen
		//			await _userManager.AddToRoleAsync(user, "Manager");

		//			// Manager erstellen und mit Benutzer verknüpfen
		//			var manager = new Manager
		//			{
		//				Department = department,
		//				ApplicationUserId = user.Id
		//			};

		//			_context.Managers.Add(manager);
		//			await _context.SaveChangesAsync();
		//		}
		//		else
		//		{
		//			throw new Exception("Benutzer konnte nicht erstellt werden.");
		//		}
		//	}
	}
}
