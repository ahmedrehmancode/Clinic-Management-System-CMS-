
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace CMS.Domain.Models
{
    public class User
    {
       
        public int UserId { get; set; }
      
        public string UserEmail { get; set; }
       
        public string UserPassword { get; set; }
      
        public string Role { get; set; }

        //   ForeignKey Clinc ko user se connect kr ne k le

        public int? ClinicId { get; set; }
       
        public virtual ClinicDetail ClinicDetail { get; set; }

        
    }
}
