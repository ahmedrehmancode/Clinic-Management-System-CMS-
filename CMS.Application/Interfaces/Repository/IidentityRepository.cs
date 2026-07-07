using CMS.Application.Features.UserProfile.Command.EditUser;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces.Repository
{
    public interface IidentityRepository
    {
        Task<User?> Resgister(User user,string password);

        
    }
}
