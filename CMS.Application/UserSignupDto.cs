using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application
{
    public class UserSignupDto
    {
        public int UserId { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public string Role { get; set; }

    }
}
