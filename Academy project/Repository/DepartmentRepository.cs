using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;

namespace Day2_MVC_Task.Repository
{
	public class DepartmentRepository : IRepository<Department>
	{
		AppDbContext _context;
        public DepartmentRepository(AppDbContext Context)
        {
            _context = Context;
        }
        public void Add(Department obj)
		{
			_context.Departments.Add(obj);
		}

		public void DeleteById(int id)
		{
			Department Dept = GetById(id);	
			_context.Departments.Remove(Dept);
		}

		public List<Department> GetAll()
		{
			return _context.Departments.ToList();	
		}

		public Department GetById(int id)
		{
			return _context.Departments.FirstOrDefault(x => x.Id == id);
		}

		public int GetCount()
		{
			return _context.Departments.Count();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Department obj)
		{
			_context.Departments.Update(obj);	
		}
	}
}
