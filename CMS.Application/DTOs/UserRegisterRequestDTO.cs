using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs
{
    public class UserRegisterRequestDTO
    {
        public string FullName { get; set; }
        public string userName { get; set; }

        public string Password { get; set; }

        public string Phone {  get; set; }
    }
}
