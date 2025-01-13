using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Day2_MVC_Task.Repository
{
	public class ResultRepository : IResultRepository
	{
		AppDbContext _context;
		public ResultRepository(AppDbContext Context)
		{
			_context = Context;
		}
		public void Add(CrsResult obj)
		{
			_context.CrsResults.Add(obj);
		}

		public void DeleteById(int id)
		{
			var obj = GetById(id);
			_context.CrsResults.Remove(obj);
		}

		public List<CrsResult> GetAll()
		{
			return _context.CrsResults.ToList();
		}

	
		public CrsResult GetById(int id)
		{
			return _context.CrsResults.FirstOrDefault(x => x.Trainee_Id == id);
		}

		public CrsResult GetByTraineeCoursId(int T_id, int C_id)
		{
			return _context.CrsResults.FirstOrDefault(x => (x.Trainee_Id == T_id) && (x.Course_Id == C_id));
		}

		public int GetCount()
		{
			return _context.CrsResults.Count();
		}

		public List<CrsResult> GetResultsByCourseId(int id)
		{
			return _context.CrsResults.Where(x =>  x.Course_Id == id).ToList();
		}

		public List<CrsResult> GetResultsByTraineeIdIncludeTraineeCourse(int id)
		{
			return _context.CrsResults.Include(x => x.Trainee).Include(x => x.Course).Where(x => x.Trainee_Id == id).ToList();
		}

		public void Save()
		{
			_context.SaveChanges();	
		}

		public void Update(CrsResult obj)
		{
			_context.CrsResults.Update(obj);	
		}
	}
}
