using Day2_MVC_Task.Models;
using Day2_MVC_Task.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day2_MVC_Task.Controllers
{
    [Authorize]
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository traineeRepository;

        public IRepository<Department> DepartmentRepository;

        public TraineeController(ITraineeRepository traineeRepository, IRepository<Department> departmentRepository)
        {
            this.traineeRepository = traineeRepository;
            DepartmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var model = traineeRepository.GetAllIncludeCrsResult();
            return View("Index", model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(int id)
        {
            var model = traineeRepository.GetById(id);
            if(model != null)
            {
                ViewBag.Depts = DepartmentRepository.GetAll();
                return View("Edit", model); 
            }
            return View("index");
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(Trainee TraineeFromView)
        {
            if(ModelState.IsValid)
            {
                traineeRepository.Update(TraineeFromView);
                traineeRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Depts = DepartmentRepository.GetAll();
            return View("Edit", TraineeFromView);
        }
    }
}
