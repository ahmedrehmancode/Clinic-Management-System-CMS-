using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces
{
     public interface IUserSignupRepository
    {
        Task<bool> RegisterAsync(UserDto admin);


        Task<User> GetByEmailAsync(string email);
        
       
    }
}
