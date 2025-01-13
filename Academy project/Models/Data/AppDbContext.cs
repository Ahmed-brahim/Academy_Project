using Day2_MVC_Task.Models.Data.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day2_MVC_Task.Models.Data
{
	public class AppDbContext:IdentityDbContext	//DbContext
	{
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Course> courses { get; set; }
		public DbSet<CrsResult> CrsResults { get; set; }

        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfig).Assembly);
		}
	}
}
