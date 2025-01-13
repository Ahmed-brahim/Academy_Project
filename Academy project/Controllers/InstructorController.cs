using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Day2_MVC_Task.Repository;
using Day2_MVC_Task.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day2_MVC_Task.Controllers
{
    [Authorize]
    public class InstructorController : Controller
	{
		IinstructorRepository _instructorRepository;
        ICourseRepository _courseRepository;
        IRepository<Department> _departmentRepository;
		public InstructorController(IinstructorRepository instructorRepository, ICourseRepository courseRepository, IRepository<Department> departmentRepository)
        {
            _instructorRepository = instructorRepository;
			_courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
		}
        
        public IActionResult Index()
		{
			var InstructorsModel = _instructorRepository.GetAllIncludeCourseDepartment();    //Context.Instructors.Include(e=>e.Course).Include(e => e.Department).ToList();

			return View("Index", InstructorsModel);
		}
		public IActionResult Detail(int id)
		{
            Instructor InstructorsModel = _instructorRepository.GetByIdIncludeCourseDepartment(id); //Context.Instructors.Include(e => e.Course).Include(e => e.Department).FirstOrDefault(x => x.Id == id);
			return View("detail", InstructorsModel);
        }
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult EditInstructor(int id)
		{
            /*var Model = new InstructorViewModel();
            Model.Instructor = Context.Instructors.FirstOrDefault(x => x.Id == id);
            var DepartmentsList = Context.Departments.AsNoTracking().ToList();
            var CoursesList = Context.courses.AsNoTracking().ToList();
            Model.Courses = CoursesList;
            Model.Departments = DepartmentsList;*/
            var model = _instructorRepository.GetById(id);          // Context.Instructors.FirstOrDefault(x => x.Id == id);
            ViewBag.CoursesList = _courseRepository.GetAll();       //Context.courses.AsNoTracking().ToList();
            ViewBag.DepartmentsList = _departmentRepository.GetAll();          //Context.Departments.AsNoTracking().ToList();
            return View("EditInstructor", model);
		}
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult SaveInstructor(Instructor InstructorFromView)
		{
			if (ModelState.IsValid)
			{
                var InstructorFromDb = _instructorRepository.GetById(InstructorFromView.Id);     //Context.Instructors.FirstOrDefault(x => x.Id == InstructorFromView.Id);
                InstructorFromDb.Name = InstructorFromView.Name;
                InstructorFromDb.Salary = InstructorFromView.Salary;
                InstructorFromDb.Crs_id = InstructorFromView.Crs_id;
                InstructorFromDb.Dept_id = InstructorFromView.Dept_id;
                InstructorFromDb.Address = InstructorFromView.Address;
                InstructorFromDb.Image = InstructorFromView.Image;
                _instructorRepository.Save();   //Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoursesList = _courseRepository.GetAll();   //Context.courses.AsNoTracking().ToList();
			ViewBag.DepartmentsList = _departmentRepository.GetAll();       //Context.Departments.AsNoTracking().ToList();
			return View("EditInstructor", InstructorFromView);

        }
        [Authorize]
        public IActionResult AddNewInstructor()
		{
			ViewBag.CoursesList = _courseRepository.GetAll();   //Context.courses.AsNoTracking().ToList();
			ViewBag.DepartmentsList = _departmentRepository.GetAll();       //Context.Departments.AsNoTracking().ToList();
			return View("AddNewInstructor");
        }
        [HttpPost]
        [Authorize]
        public IActionResult SaveNewInstructor(Instructor InstructorFromView)
        {
            InstructorFromView.Image = "image.jpeg";
            if (ModelState.IsValid)
            {
                _instructorRepository.Add(InstructorFromView);      //Context.Instructors.Add(InstructorFromView);
                _instructorRepository.Save();//Context.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.CoursesList = _courseRepository.GetAll();   //Context.courses.AsNoTracking().ToList();
			ViewBag.DepartmentsList = _departmentRepository.GetAll();       //Context.Departments.AsNoTracking().ToList();
			return View("AddNewInstructor", InstructorFromView);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult DeleteInstructor(int id) 
        {
            _instructorRepository.DeleteById(id);
            _departmentRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
