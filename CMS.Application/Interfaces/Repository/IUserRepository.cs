using CMS.Application.DTOs;
using CMS.Application.Features.User.Command.EditUser;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> GetById(string Id);
        Task<User> GetByEmail(string Email);
        Task<bool> EditUser(User user);
        Task<bool> DeleteUser(string Id);
    }
}
