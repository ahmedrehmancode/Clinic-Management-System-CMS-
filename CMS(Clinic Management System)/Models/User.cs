using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace CMS_Clinic_Management_System_.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string Role { get; set; }

        //   ForeignKey Clinc ko user se connect kr ne k le

        public int? ClinicId { get; set; }
        [ForeignKey("ClinicId")]
        public virtual ClinicDetail ClinicDetail { get; set; }

        
    }
}
