using Day2_MVC_Task.Models;
using Day2_MVC_Task.Models.Data;
using Day2_MVC_Task.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day2_MVC_Task.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ITraineeRepository _traineeRepository;
        private readonly IinstructorRepository _instructorRepository;

        public DepartmentController(
            IRepository<Department> departmentRepository,
            ICourseRepository courseRepository,
            ITraineeRepository traineeRepository,
            IinstructorRepository instructorRepository)
        {
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _traineeRepository = traineeRepository;
            _instructorRepository = instructorRepository;
        }

        
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View("Index", departments);
        }

        public IActionResult Detail(int id)
        {
            var department = _departmentRepository.GetById(id);
            ViewBag.CoursesList = _courseRepository.GetAll();
            ViewBag.TraineesList = _traineeRepository.GetAll();
            ViewBag.InstructorsList = _instructorRepository.GetAll();
            return View("Detail", department);
        }//still doesnt have view

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            return View("EditDepartment", department);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult SaveDepartment(Department departmentFromView)
        {
            if (ModelState.IsValid)
            {
                var departmentFromDb = _departmentRepository.GetById(departmentFromView.Id);
                departmentFromDb.Name = departmentFromView.Name;
                departmentFromDb.Manager = departmentFromView.Manager;
                // Update other properties as needed
                _departmentRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CoursesList = _courseRepository.GetAll();
            ViewBag.TraineesList = _traineeRepository.GetAll();
            ViewBag.InstructorsList = _instructorRepository.GetAll();
            return View("EditDepartment", departmentFromView);
        }

        [Authorize(Roles = "Admin, Manager")]
        public IActionResult AddNewDepartment()
        {
            return View("AddNewDepartment");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult SaveNewDepartment(Department departmentFromView)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(departmentFromView);
                _departmentRepository.Save();
                return RedirectToAction("Index");
            }

            return View("AddNewDepartment", departmentFromView);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDepartment(int id)
        {
            _departmentRepository.DeleteById(id);
            _departmentRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
