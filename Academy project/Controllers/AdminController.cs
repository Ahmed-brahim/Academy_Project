using Day2_MVC_Task.Models;
using Day2_MVC_Task.Repository;
using Day2_MVC_Task.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Mvc;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace Day2_MVC_Task.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        public UserManager<IdentityUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
		public ICourseRepository CourseRepository { get; }
		public IRepository<Department> DepartmentRepository { get; }
		public IinstructorRepository InstructorRepository { get; }
		public ITraineeRepository TraineeRepository { get; }

		public AdminController
            (UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ICourseRepository courseRepository,
            IRepository<Department> DepartmentRepository, IinstructorRepository iinstructorRepository, ITraineeRepository traineeRepository)
            
        {
            UserManager = userManager;
            RoleManager = roleManager;
			CourseRepository = courseRepository;
			this.DepartmentRepository = DepartmentRepository;
			InstructorRepository = iinstructorRepository;
			TraineeRepository = traineeRepository;
		}
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            AdminPageViewModel Model = new AdminPageViewModel();
            List<IdentityUser> Users = UserManager.Users.ToList();
            foreach (var user in Users)
            {
                UserViewModel NewUser = new UserViewModel();
                NewUser.Name = user.UserName;
                NewUser.Id = user.Id;
                NewUser.Email = user.Email;
				NewUser.Roles = (List<string>)await UserManager.GetRolesAsync(user);
                Model.Users.Add(NewUser);
            }
            ViewBag.UsersCount = UserManager.Users.Count();
            ViewBag.RolesCount = RoleManager.Roles.Count();
            ViewBag.CoursesCount = CourseRepository.GetCount();
            ViewBag.DeptsCount = DepartmentRepository.GetCount();
            ViewBag.TraineesCount = TraineeRepository.GetCount();
            ViewBag.InstructorsCount = InstructorRepository.GetCount();
            ViewBag.Roles = RoleManager.Roles.Select(x => x.Name).ToList();
			return View("index", Model);

        }
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(ChangeRoleViewModel Model)
        {
            
            if (!ModelState.IsValid || (UserManager.Users.FirstOrDefault(u => u.Id == Model.UserId).NormalizedEmail == "ADMIN@ADMIN" ))
            {
                ModelState.AddModelError("", "Cant Change Admin Account role"); //an error message defined at Change Role view model
                /************************/
                AdminPageViewModel NewModel = new AdminPageViewModel();
                List<IdentityUser> NewUsers = UserManager.Users.ToList();
                foreach (var nuser in NewUsers)
                {
                    UserViewModel NewUser = new UserViewModel();
                    NewUser.Name = nuser.UserName;
                    NewUser.Id = nuser.Id;
                    NewUser.Email = nuser.Email;
                    NewUser.Roles = (List<string>)await UserManager.GetRolesAsync(nuser);
                    NewModel.Users.Add(NewUser);
                }
                ViewBag.UsersCount = UserManager.Users.Count();
                ViewBag.RolesCount = RoleManager.Roles.Count();
                ViewBag.CoursesCount = CourseRepository.GetCount();
                ViewBag.DeptsCount = DepartmentRepository.GetCount();
                ViewBag.TraineesCount = TraineeRepository.GetCount();
                ViewBag.InstructorsCount = InstructorRepository.GetCount();
                ViewBag.Roles = RoleManager.Roles.Select(x => x.Name).ToList();
                return View("index", NewModel);
                /************************/

            }
            if (Model.NewRole != "No Role"  && !await RoleManager.RoleExistsAsync(Model.NewRole))
            {
                return RedirectToAction("Error", "Home");
            }
            var user = await UserManager.FindByIdAsync(Model.UserId);
            if (user == null) 
            {
                return RedirectToAction("Error", "Home");
            }
            var roles = await UserManager.GetRolesAsync(user);
            await UserManager.RemoveFromRolesAsync(user, roles);
            if(Model.NewRole != "No Role")
            {
                await UserManager.AddToRoleAsync(user, Model.NewRole);
            }
            return RedirectToAction("Index"); 
        }
        public async Task<IActionResult> DeleteUser(string UserId)
        {
            if (UserId == null || (UserManager.Users.FirstOrDefault(u => u.Id == UserId).NormalizedEmail == "ADMIN@ADMIN"))
            {
                return RedirectToAction("Error", "Home");
            }
            var user = await UserManager.FindByIdAsync(UserId);
            var result = await UserManager.DeleteAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
