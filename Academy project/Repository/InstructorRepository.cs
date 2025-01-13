using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Day2_MVC_Task.Repository
{
	public class InstructorRepository : IinstructorRepository
	{
		private readonly AppDbContext _Context;
		public InstructorRepository(AppDbContext context)
		{
			_Context = context;

		}
		public void Add(Instructor obj)
		{
			_Context.Instructors.Add(obj);
		}

		public void DeleteById(int id)
		{
			Instructor instructor = GetById(id);
			_Context.Instructors.Remove(instructor);
		}

		public List<Instructor> GetAll()
		{
			return _Context.Instructors.ToList();
		}

		public List<Instructor> GetAllIncludeCourseDepartment()
		{
			return _Context.Instructors.Include(x => x.Course).Include(x => x.Department).ToList();
		}
		public Instructor GetById(int id)
		{
			return _Context.Instructors.FirstOrDefault(x => x.Id == id);
		}

		public Instructor GetByIdIncludeCourseDepartment(int id)
		{
			return _Context.Instructors.Include(x => x.Course).Include(x => x.Department).FirstOrDefault(x => x.Id == id);
		}

		public int GetCount()
		{
			return _Context.Instructors.Count();
		}

		public void Save()
		{
			_Context.SaveChanges();
		}

		public void Update(Instructor obj)
		{
			_Context.Instructors.Update(obj);
		}
	}
}


