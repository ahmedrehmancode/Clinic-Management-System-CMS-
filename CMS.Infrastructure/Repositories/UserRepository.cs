using AutoMapper;
using CMS.Application.Features.UserProfile.Command.EditUser;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Entities;
using CMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task<bool> DeleteUser(string Id)
        {
            var exestingUser = await _userManager.FindByIdAsync(Id);
            if (exestingUser == null) return false;
            var DeleteUser = await _userManager.DeleteAsync(exestingUser);
            return DeleteUser.Succeeded;

        }

        public async Task<bool> EditUser(User user)
        {
            var exestingUser = await _userManager.FindByIdAsync(user.Id);
            if (exestingUser == null) return false;
            _mapper.Map(user, exestingUser);
            var Update = await _userManager.UpdateAsync(exestingUser);
            return Update.Succeeded;

        }

        public async Task<User?> GetByEmail(string Email)
        {
            ApplicationUser? ExestingUser = await _userManager.FindByNameAsync(Email);
            if (ExestingUser == null) return null;
            return _mapper.Map<User>(ExestingUser);
        }

        public async Task<User?> GetById(string Id)
        {
            ApplicationUser? ExestingUser = await _userManager.FindByIdAsync(Id);
            if (ExestingUser == null) return null;
            return _mapper.Map<User>(ExestingUser);

        }
    }
}
