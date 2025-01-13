using Day2_MVC_Task.Models;

namespace Day2_MVC_Task.Repository
{
	public interface IResultRepository:IRepository<CrsResult>
	{
		public CrsResult GetByTraineeCoursId(int T_id, int C_id);
		public List<CrsResult> GetResultsByCourseId(int id);
		public List<CrsResult> GetResultsByTraineeIdIncludeTraineeCourse(int id);
	}
}
