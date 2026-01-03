using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace CMS_Clinic_Management_System_.Models
{
    public class Clinic
    {
        // ye data clinic table k le
        [Key]
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "Enter Clinic Name")]
        public string ClinicName { get; set;  }

        [Required(ErrorMessage = "Enter Clinic Address")]
        public string ClinicAddress { get; set; }
        [Required(ErrorMessage = "Enter Contact Number")]
        public string ContactNumber { get; set; }

        // ye data login table k le
        [Required(ErrorMessage ="Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        public string Passowrd { get; set; }
    }
}
