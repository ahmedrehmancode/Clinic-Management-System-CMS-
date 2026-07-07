using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public required string FullName { get; set; }

        public bool? IsClinicAccount { get; set; }

        public bool Status { get; set; }
    }
}
