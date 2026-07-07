using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.UserProfile.Command.EditUser
{
    public class RequestDTO
    {
        public required string UserId { get; set; }

        public required string UserName { get; set; }
        
        public required string FullName { get; set; }


    }
}
