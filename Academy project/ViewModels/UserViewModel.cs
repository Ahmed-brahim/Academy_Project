namespace Day2_MVC_Task.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } // User ID
        public string Name { get; set; } // User Name
        public string Email { get; set; }   // user email
        public List<string> Roles { get; set; } // User Roles
    }
}
