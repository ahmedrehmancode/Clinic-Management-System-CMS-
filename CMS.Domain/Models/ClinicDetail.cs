using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Transactions;

namespace CMS.Domain.Models
{
    public class ClinicDetail
    {
        

        // ye data clinic table k le
      
        public int ClinicId { get; set; }


        public string ClinicName { get; set;  }
       
       
        public string Address { get; set; }

        public string Phone { get; set; }

        
       public string UserId { get; set; }
        
    }
}
