using Day2_MVC_Task.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day2_MVC_Task.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterUserViewModel UserFromView)
		{
			if (ModelState.IsValid)
			{
                // Check if email is already taken
                var existingUser = await userManager.FindByEmailAsync(UserFromView.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(UserFromView);
                }
                //mapping
                IdentityUser user = new IdentityUser();
				user.UserName = UserFromView.UserName;
				user.Email = UserFromView.Email;
				user.PasswordHash = UserFromView.Password;
                
                //store at database
                IdentityResult Result = await userManager.CreateAsync(user, UserFromView.Password);
				
				if (Result.Succeeded)
				{
                    //create cookie
                    await signInManager.SignInAsync(user, false);
					return RedirectToAction("Index", "Home");
				}
				foreach (var R in Result.Errors)
				{
					ModelState.AddModelError("", R.Description);
				}
			}
			return View("Register", UserFromView);
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View("Login");
		}
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel UserFromView)
        {
			if (ModelState.IsValid)
			{
				IdentityUser user = await userManager.FindByEmailAsync(UserFromView.Email);
				if (user != null)
				{
					bool found = await userManager.CheckPasswordAsync(user, UserFromView.Password);
					if (found)
					{ 
						await signInManager.SignInAsync(user, UserFromView.RememberMe);
						return RedirectToAction("Index", "Home");
					}
				}
			}
			ModelState.AddModelError("", "Email Or password incorrect");
			return View("Login",UserFromView);
        }
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Login", "Account");
		}
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult AddRole()
		{
			return View("AddRole");
		}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(RoleViewModel RoleModel)
        {
            if(ModelState.IsValid)
			{
				IdentityRole identityRole = new IdentityRole();
				identityRole.Name = RoleModel.Name;
				IdentityResult result = await roleManager.CreateAsync(identityRole);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				foreach (var r in result.Errors)
				{
					ModelState.AddModelError("", r.Description);
				}
			}
			return View("AddRole",RoleModel);
        }
    }
}
