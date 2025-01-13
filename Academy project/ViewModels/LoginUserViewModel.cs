using System.ComponentModel.DataAnnotations;

namespace Day2_MVC_Task.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]   
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Boolean RememberMe { get; set; }
    }
}
