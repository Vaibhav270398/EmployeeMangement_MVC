using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement_MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; } = "";
        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; } = "";
    }
}
