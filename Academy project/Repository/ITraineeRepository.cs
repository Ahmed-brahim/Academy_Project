using Day2_MVC_Task.Models;

namespace Day2_MVC_Task.Repository
{
    public interface ITraineeRepository:IRepository<Trainee>
    {
        public List<Trainee> GetAllIncludeCrsResult();
    }
}
