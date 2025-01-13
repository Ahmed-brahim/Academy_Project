namespace Day2_MVC_Task.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; } 
		public string? Manager { get; set; }
		public List<Course>? Courses;
		public List<Trainee>? Trainees;
		public List<Instructor>? Instructors;
	}
}
