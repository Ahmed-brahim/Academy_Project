using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Day2_MVC_Task.Repository
{
	public class CourseRepository : IRepository<Course>, ICourseRepository
	{
		AppDbContext _context;
        public CourseRepository(AppDbContext Context)
        {
            _context = Context;
        }

		public void Add(Course obj)
		{
			_context.courses.Add(obj);	
		}

		public void DeleteById(int id)
		{
			Course course = GetById(id);
			_context.courses.Remove(course);
		}

		public List<Course> GetAll()
		{
			return _context.courses.ToList();
		}

		public List<Course> GetAllIncludeDepartment()
		{
			return _context.courses.Include(x => x.Department).ToList();
		}

		public Course GetById(int id)
		{
			return _context.courses.FirstOrDefault(c => c.Id == id);
		}

		public int GetCount()
		{
			return _context.courses.Count();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Course obj)
		{
			_context.Update(obj);
		}
	}
}
