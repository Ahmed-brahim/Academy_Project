namespace Day2_MVC_Task.ViewModels
{
    public class AdminPageViewModel
    {
        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();// Your original model
        public ChangeRoleViewModel ChangeRole { get; set; } // Model for the change role form
    }
}
