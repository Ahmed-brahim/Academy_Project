namespace Day2_MVC_Task.Models
{
	public class CrsResult
	{
		public int Trainee_Id { get; set; }
		public Trainee Trainee { get; set; }
		public int Course_Id { get; set; }
		public Course Course { get; set; }	
		public int Degree { get; set; }
	}
}
