using AutoMapper;
using CMS.Application.DTOs;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Entities;
using CMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories
{
    public class IdentityRepository : IidentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public IdentityRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<User> Resgister(User user, string password)
        {
            ApplicationUser createRequest = _mapper.Map<ApplicationUser>(user);
            createRequest.UserName = user.Email;
            IdentityResult CreateUser = await _userManager.CreateAsync(createRequest, password);
            if (CreateUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(createRequest, "Clinic");
                var newUser = _mapper.Map<User>(createRequest);
                return newUser;
            }
            return null;
        }
    }
}

