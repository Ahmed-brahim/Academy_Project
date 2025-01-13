using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Day2_MVC_Task.Repository
{
	public class TraineeRepository : ITraineeRepository
    {
		AppDbContext _context;
		public TraineeRepository(AppDbContext Context)
		{
			_context = Context;
		}
		public void Add(Trainee obj)
		{
			_context.Trainees.Add(obj);	
		}

		public void DeleteById(int id)
		{
			Trainee obj = GetById(id);
			_context.Trainees.Remove(obj);	
		}

		public List<Trainee> GetAll()
		{
			return _context.Trainees.ToList();
		}
		public List<Trainee> GetAllIncludeCrsResult()
		{
			return _context.Trainees.Include(x => x.CrsResults).ToList();	
		}
        public Trainee GetById(int id)
		{
			return _context.Trainees.FirstOrDefault(x => x.Id == id);
		}

		public int GetCount()
		{
			return _context.Trainees.Count();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Trainee obj)
		{
			_context.Trainees.Update(obj);	
		}
	}
}
