using CMS.Application.DTOs;
using CMS.Application.Features.User.Command.EditUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces.Service
{
    public interface IidentityService
    {
        Task<bool> Adduser(UserRegisterRequestDTO requestDTO);
        Task<UserResponseDTO> GetById(string Id);
        Task<UserResponseDTO> GetByEmail(string Email);
        Task<bool> EditUser(RequestDTO request);
        Task<bool> DeleteUser(string  Id);
    }
}
