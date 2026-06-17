using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.User.Command.EditUser
{
    public class RequestDTO
    {
        public string UserId { get; set; }

        public string UserName { get; set; }
        
        public string FullName { get; set; }


    }
}
