using System.ComponentModel.DataAnnotations;

namespace Day2_MVC_Task.Models
{
	public class Instructor
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Name is Required")]
		[MinLength(2,ErrorMessage ="Name Must Be more Than 2 characters")]
		[MaxLength(30, ErrorMessage = "Name Must Be less Than 30 characters")]
		public string Name { get; set; }
		
		//Regular Expression attribute
		public string? Image { get; set; }
		[Required(ErrorMessage = "salary is required")]
		[Range(6000 , 50000, ErrorMessage ="Salary Must be Between 6000 and 50000")]
		public int Salary { get; set; }
		[Required(ErrorMessage = "Address is Required")]
		[MinLength(3, ErrorMessage = "Address Must Be more Than 3 characters")]
		[MaxLength(20, ErrorMessage = "Adress Must Be less Than 20 characters")]
		public string Address { get; set; }
		public Course? Course { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage ="please Select Course")]
		public int? Crs_id { get; set; }
		public Department? Department { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "please Select Department")]
		public int? Dept_id { get; set;}
	}
}
