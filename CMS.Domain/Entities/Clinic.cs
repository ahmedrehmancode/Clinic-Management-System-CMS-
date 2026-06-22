using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string ClinicName { get; set; }

        public string ClinicRegistraionNumber { get; set; }

        public string Address { get; set; }

        public string UserId {  get; set; }


    }
}
