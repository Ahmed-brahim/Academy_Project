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
    public class ResultController : Controller
    {
		IResultRepository _resultRepository;
        ICourseRepository _courseRepository;
        ITraineeRepository _traineeRepository;
		public ResultController(IResultRepository resultRepository, ICourseRepository courseRepository, ITraineeRepository traineeRepository)
		{
			_resultRepository = resultRepository;
            _courseRepository = courseRepository;   
            _traineeRepository = traineeRepository;
		}
		public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult GetResult()
        {
            ViewBag.Courses = _courseRepository.GetAll();//Context.courses.AsNoTracking().ToList();
            return View("GetResult");
        }
        [HttpPost]
        public IActionResult ShowResult(CrsResult CrsResultFromView)
        {
            var result = _resultRepository.GetByTraineeCoursId(CrsResultFromView.Trainee_Id, CrsResultFromView.Course_Id);//Context.CrsResults.FirstOrDefault(x => (x.Trainee_Id == CrsResultFromView.Trainee_Id) && (x.Course_Id == CrsResultFromView.Course_Id));

			if (_traineeRepository.GetById(CrsResultFromView.Trainee_Id) == null)
            {
                ModelState.AddModelError("Trainee_Id", "Trainee Id doesn't exist");
				ViewBag.Courses = _courseRepository.GetAll();   //Context.courses.AsNoTracking().ToList();
				return View("GetResult", CrsResultFromView);
			}
            else if (result == null)
            {
                ModelState.AddModelError("Course_id", "Trainee Didn't Enroll in this Course");
				ViewBag.Courses = _courseRepository.GetAll(); //Context.courses.AsNoTracking().ToList();
				return View("GetResult", CrsResultFromView);
            }
            ResultViewModel Model = new ResultViewModel();
            var Course = _courseRepository.GetById(result.Course_Id);   //Context.courses.FirstOrDefault(x => x.Id == result.Course_Id);
            Model.Name = _traineeRepository.GetById(result.Trainee_Id).Name;  //Context.Trainees.FirstOrDefault(x => x.Id == result.Trainee_Id).Name;
            Model.CourseName = Course.Name;
            Model.Result = result.Degree;
            if (result.Degree >= Course.MinDegree)
            {
                Model.Color = "Green";
                Model.Status = "pass";
            }
            else
            {
                Model.Color = "Red";
                Model.Status = "Fail";
            }
            return View("ShowResult", Model);
        }
        public IActionResult CourseResult()
        {
            ViewBag.Courses = _courseRepository.GetAll();   //Context.courses.AsNoTracking().ToList();  
            return View("CourseResult");
        }
        public IActionResult ShowCourseResult(int id)
        { 
            List<ResultViewModel> Model = new List<ResultViewModel>();
            var CrsResults = _resultRepository.GetResultsByCourseId(id);    //Context.CrsResults.AsNoTracking().Where(x => x.Course_Id == id).ToList();
            var trainees = _traineeRepository.GetAll(); //Context.Trainees.AsNoTracking().ToList();
            var Course = _courseRepository.GetById(id); //Context.courses.AsNoTracking().FirstOrDefault(x => x.Id == id);
            foreach (var C in CrsResults)
            {
				var temp = new ResultViewModel(); temp.Name = trainees.First(x => x.Id == C.Trainee_Id).Name;
                temp.CourseName = Course.Name;
                temp.Result = C.Degree;
                if (temp.Result >= Course.MinDegree)
                {
                    temp.Color = "Green";
                    temp.Status = "Pass";
                }
                else
                {
					temp.Color = "Red";
					temp.Status = "Fail";
				}
                Model.Add(temp);
            }
            return View("ShowCourseResult", Model);
        }
        public IActionResult TraineeResult()
        {
            return View("TraineeResult");
        }
        
        public IActionResult ShowTraineeResult(int Id)
        {
            //Context.Trainees.FirstOrDefault(x => x.Id == TraineeFromView.Id)
            var trainee = _traineeRepository.GetById(Id);

            if (trainee == null)
            {
                ModelState.AddModelError("Id", "Trainee Id doesn't exist");
				return View("TraineeResult", trainee);
			}
            List<ResultViewModel> Model = new List<ResultViewModel>();
            var CrsResults = _resultRepository.GetResultsByTraineeIdIncludeTraineeCourse(Id);
			foreach (var C in CrsResults)
            {

				var temp = new ResultViewModel(); temp.Name = C.Trainee.Name;  //TraineeName;
                temp.CourseName = C.Course.Name;
                temp.Result = C.Degree;
                if (temp.Result >= C.Course.MinDegree)
                {
                    temp.Color = "Green";
                    temp.Status = "Pass";
                }
                else
                {
                    temp.Color = "Red";
                    temp.Status = "Fail";
                }
                Model.Add(temp);
            }
            return View("ShowTraineeResult", Model);
        }

    }
}
