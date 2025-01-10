using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PVM.Models;
using System.Reflection.Emit;

namespace PVM.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
		public DbSet<Manager> Managers { get; set; }
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
			// Beziehung zwischen Manager und Address
			builder.Entity<Manager>()
				.HasOne(f => f.Address)
				.WithOne()
				.HasForeignKey<Manager>(f => f.AddressId)
				.OnDelete(DeleteBehavior.Restrict); 
			// Beziehung zwischen Department und Employee
			builder.Entity<Employee>()
				.HasOne(e => e.Department)
				.WithMany(d => d.Employees) 
				.HasForeignKey(e => e.DepartmentId)
				.OnDelete(DeleteBehavior.Restrict); 

			// Beziehung zwischen Department und Manager
			builder.Entity<Manager>()
				.HasOne(m => m.Department)
				.WithOne(d => d.Manager) // 1-zu-1-Beziehung
				.HasForeignKey<Manager>(m => m.DepartmentId)
				.OnDelete(DeleteBehavior.Restrict);
			// Beziehung zwischen ApplicationUser und Employee
			//builder.Entity<ApplicationUser>()
			//	.HasOne(u => u.Employee) // Ein Benutzer hat einen Mitarbeiter
			//	.WithOne(e => e.ApplicationUser) // Ein Mitarbeiter gehört zu einem Benutzer
			//	.HasForeignKey<Employee>(e => e.ApplicationUserId) // Fremdschlüssel in Employee
			//	.OnDelete(DeleteBehavior.Cascade); // Löscht den Mitarbeiter, wenn der Benutzer gelöscht wird
			//// Beziehung zwischen ApplicationUser und Manager
			//builder.Entity<ApplicationUser>()
			//	.HasOne(u => u.Manager) // Ein Benutzer kann ein Manager sein
			//	.WithOne(m => m.ApplicationUser) // Ein Manager gehört zu einem Benutzer
			//	.HasForeignKey<Manager>(m => m.ApplicationUserId) // Fremdschlüssel in Manager
			//	.OnDelete(DeleteBehavior.Cascade); // Löscht den Manager, wenn der Benutzer gelöscht wird
		}
	}
}
