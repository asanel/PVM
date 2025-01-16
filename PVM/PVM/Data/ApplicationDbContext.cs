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


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


			// Beziehung zwischen Employee und Address
			builder.Entity<Employee>()
				.HasOne(f => f.Address)
				.WithOne()
				.HasForeignKey<Employee>(f => f.AddressId)
				.OnDelete(DeleteBehavior.Restrict);
			//// Beziehung zwischen Manager und Address
			//builder.Entity<Manager>()
			//	.HasOne(f => f.Address)
			//	.WithOne()
			//	.HasForeignKey<Manager>(f => f.AddressId)
			//	.OnDelete(DeleteBehavior.Restrict); 
			// Beziehung zwischen Department und Employee
			//builder.Entity<Employee>()
			//	.HasOne(e => e.Department)
			//	.WithMany(d => d.Employees) 
			//	.HasForeignKey(e => e.DepartmentId)
			//	.OnDelete(DeleteBehavior.Restrict); 

			//// Beziehung zwischen Department und Manager
			//builder.Entity<Manager>()
			//	.HasOne(m => m.Department)
			//	.WithOne(d => d.Manager) // 1-zu-1-Beziehung
			//	.HasForeignKey<Manager>(m => m.DepartmentId)
			//	.OnDelete(DeleteBehavior.Restrict);


			// Beziehung: ApplicationUser -> Employee (1:1)
			builder.Entity<ApplicationUser>()
				.HasOne(u => u.Employee)
				.WithOne(e => e.ApplicationUser)
				.HasForeignKey<ApplicationUser>(u => u.EmployeeId)
				.OnDelete(DeleteBehavior.Restrict);

			//	// Beziehung: ApplicationUser -> Manager (1:1)
			//	builder.Entity<ApplicationUser>()
			//		.HasOne(u => u.Manager)
			//		.WithOne(m => m.ApplicationUser) 
			//		.HasForeignKey<ApplicationUser>(u => u.ManagerId)
			//		.OnDelete(DeleteBehavior.Restrict); 
		}
	}
}
