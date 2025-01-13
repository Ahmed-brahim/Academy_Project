/*using Day2_MVC_Task.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Day2_MVC_Task.Models
{
	public class UniqeCourseNameAttribute:ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
				return null;
			string NewName = value.ToString();
			using (var Context = new AppDbContext())
			{
				var model = Context.courses.FirstOrDefault(x => x.Name.ToLower() == NewName.ToLower());
				if (model != null)
					return new ValidationResult("Name Must be Unique");
			}
			return ValidationResult.Success;
		}
	}
}*/
