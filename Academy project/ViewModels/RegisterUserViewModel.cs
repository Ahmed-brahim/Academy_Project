using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Day2_MVC_Task.ViewModels
{
	public class RegisterUserViewModel
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]	
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Confirm Password")]
		[Compare("Password",ErrorMessage = "Password and Confirm Password Don't Match")]
		public string ConfirmPassword { get; set; }
	}
}
