using System.ComponentModel.DataAnnotations;

namespace CMS_Clinic_Management_System_.ViewModels
{
    public class SignupViewModle
    {
        [Required(ErrorMessage = "Clinic Name is Required")]
        public string ClinicName { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        [MinLength(11)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]

        
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Conform Password is required")]

        public string Conformpassword { get; set; }

    }
}
