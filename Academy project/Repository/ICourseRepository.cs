using Day2_MVC_Task.Models;

namespace Day2_MVC_Task.Repository
{
	public interface ICourseRepository:IRepository<Course>
	{
		public List<Course> GetAllIncludeDepartment();
		//public Course GetByIdInclude
	}
}
