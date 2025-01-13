using System.ComponentModel.DataAnnotations;

namespace Day2_MVC_Task.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string Name {  get; set; }   
    }
}
