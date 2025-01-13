using System.ComponentModel;

namespace Day2_MVC_Task.Models
{
	public class Trainee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Image {  get; set; }
		public string Address { get; set; }
		[DisplayName("Age")]
		public int Grade {  get; set; }
		public Department? Department { get; set; }
		public int? Dept_id { get; set; }
		public List<CrsResult>? CrsResults { get; set; }
	}
}
