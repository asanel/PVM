using Microsoft.AspNetCore.Identity;
using PVM.Models;

namespace PVM.Data
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser
	{

		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }

	}

}
