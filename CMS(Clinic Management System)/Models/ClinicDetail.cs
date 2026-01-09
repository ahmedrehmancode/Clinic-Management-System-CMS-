using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace CMS_Clinic_Management_System_.Models
{
    public class ClinicDetail
    {
        

        // ye data clinic table k le
        [Key]
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "Enter Clinic Name")]
        public string ClinicName { get; set;  }
       

        [Required(ErrorMessage = "Enter Clinic Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Clinic Phone")]
        public string Phone { get; set; }

        // virtual k clinic details ko user tk le jainge
        public virtual User User { get; set; }
    }
}
