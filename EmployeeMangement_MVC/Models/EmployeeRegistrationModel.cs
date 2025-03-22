using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EmployeeMangement_MVC.Models
{
    public class EmployeeRegistrationModel
    {
        [Required(ErrorMessage ="Please Enter Name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter City.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter PinCode.")]
        public int PinCode { get; set; }
        [Required(ErrorMessage = "Please Enter MobileNumber.")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Please Enter EmailID.")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Please Enter Uername.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password.")]
        public string Password { get; set; }
        public int Gender { get; set; }
        [Required(ErrorMessage = "Please Select DateOfBirth.")]
        public string DateOfBirth { get; set; }


    }
}
