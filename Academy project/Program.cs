using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Day2_MVC_Task.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace Day2_MVC_Task
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			
			builder.Services.AddDbContext<AppDbContext>(
                        options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
           

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(Option => Option.Password.RequireNonAlphanumeric = false).AddEntityFrameworkStores<AppDbContext>();
			//custom Services
			builder.Services.AddScoped<ICourseRepository, CourseRepository>();
			builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
			builder.Services.AddScoped<IinstructorRepository, InstructorRepository>();
			builder.Services.AddScoped<IResultRepository, ResultRepository>();
			builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();

			app.UseAuthorization();

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
