using Dev.Ikea.DAL.Models.Departments;
using Dev.Ikea.DAL.Models.Employees;
using Dev.Ikea.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dev.Ikea.DAL.Presistence.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employee { get; set; }
	}
}
