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
        public required string ClinicName { get; set; }

        public required string ClinicRegistraionNumber { get; set; }

        public required string Address { get; set; }

        public required string UserId {  get; set; }


    }
}
