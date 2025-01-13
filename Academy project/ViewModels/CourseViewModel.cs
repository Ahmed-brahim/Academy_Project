using Day2_MVC_Task.Models;

namespace Day2_MVC_Task.ViewModels
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Dept_id { get; set; }
        public List<Department> departments { get; set; }
    }
}
