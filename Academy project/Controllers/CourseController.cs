using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Day2_MVC_Task.Repository;
using Day2_MVC_Task.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Day2_MVC_Task.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
		ICourseRepository _courseRepository;
		IRepository<Department> _departmentRepository;
		public CourseController(ICourseRepository courseRepository, IRepository<Department> departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
		}
        public IActionResult Index()
        {
            var CourseModel = _courseRepository.GetAllIncludeDepartment();           
            return View("Index" , CourseModel);
        }
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult AddNewCourse()
        {
            ViewBag.DeptList = _departmentRepository.GetAll();
			return View("AddNewCourse");
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult SaveNewCourse(Course CourseFromview)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(CourseFromview);        //Context.courses.Add(CourseFromview);
                _courseRepository.Save();           //Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptList = _departmentRepository.GetAll();  //Context.Departments.AsNoTracking().ToList();
            return View("AddNewCourse" , CourseFromview);
        }
        public IActionResult CheckUniqe(string Name, int id = 0)
        {
            if (Name == null)
                return null;
            string NewName = Name;
			var model =  _courseRepository.GetAll().FirstOrDefault(x => (x.Name.ToLower() == NewName.ToLower()) && x.Id != id );     //var model = Context.courses.FirstOrDefault(x => x.Name.ToLower() == NewName.ToLower());
			if (model != null)
                return Json(false);
           
            return Json(true);
        }
        [HttpGet]
        [Authorize(Roles ="Admin, Manager")]
        public IActionResult Edit(int id)
        {
            var model = _courseRepository.GetById(id);
            ViewBag.Departments = _departmentRepository.GetAll();
            return View("Edit", model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult Edit(Course course) 
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(course);
                _courseRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Edit", course);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _courseRepository.DeleteById(id);
            _courseRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
