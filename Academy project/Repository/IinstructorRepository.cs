using Day2_MVC_Task.Models;

namespace Day2_MVC_Task.Repository
{
	public interface IinstructorRepository:IRepository<Instructor>
	{
		public List<Instructor> GetAllIncludeCourseDepartment();
		public Instructor GetByIdIncludeCourseDepartment(int id);	
			
	}
}
