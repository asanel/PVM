using Microsoft.AspNetCore.Identity;
using PVM.Models;
using System.ComponentModel.DataAnnotations;

namespace PVM.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public Employee Employee { get; set; }  

        public Manager Manager { get; set; }    

    }

}
