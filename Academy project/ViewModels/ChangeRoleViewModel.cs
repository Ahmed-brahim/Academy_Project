using System.ComponentModel.DataAnnotations;

namespace Day2_MVC_Task.ViewModels
{
    public class ChangeRoleViewModel
    {
        [Required(ErrorMessage = "Please select a role.")]
        public string NewRole { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
