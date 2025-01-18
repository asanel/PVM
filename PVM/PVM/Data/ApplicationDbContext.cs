using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PVM.Models;

namespace PVM.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<AbsenceEntry> AbsenceEntries { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


			// Beziehung zwischen Employee und Address
			builder.Entity<Employee>()
				.HasOne(f => f.Address)
				.WithOne()
				.HasForeignKey<Employee>(f => f.AddressId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Employee>()
				.HasIndex(e => new { e.Firstname, e.Lastname })
				.IsUnique();

			builder.Entity<ApplicationUser>()
				.HasOne(u => u.Employee)
				.WithOne(e => e.ApplicationUser)
				.HasForeignKey<ApplicationUser>(u => u.EmployeeId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Department>()
				.HasIndex(d => d.Name)
				.IsUnique();
		}
	}
}
