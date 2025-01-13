using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using RemoteAttribute = Microsoft.AspNetCore.Mvc.RemoteAttribute;

namespace Day2_MVC_Task.Models
{
	public class Course
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[MinLength(2, ErrorMessage = "Name Must Be more Than 2 characters")]
		[MaxLength(20, ErrorMessage = "Name Must Be less Than 20 characters")]
		//[UniqeCourseName]
		[Remote(action: "CheckUniqe", controller:"Course",AdditionalFields = "Id",ErrorMessage ="Course Name Must be unique")]
		public string Name { get; set; }

		[Required(ErrorMessage ="Degree is Required")]
		[Range(80, 100, ErrorMessage = "degree Must be between 80 and 100")]
		public int Degree {  get; set; }

		[Required(ErrorMessage = "Min Degree is Required")]
		[Range (40, 50, ErrorMessage = "Min Degree Must be between 40 and 50")]
        public int MinDegree {  get; set; }

		[Required(ErrorMessage = "please Select Department")]
		[Range(1,int.MaxValue,ErrorMessage = "please Select Department")]
		public int? Dept_id { get; set; }

		public Department? Department;
		public List<Instructor>? Instructors { get; set; }
		public List<CrsResult>? CrsResults { get; set; }
	}
}
