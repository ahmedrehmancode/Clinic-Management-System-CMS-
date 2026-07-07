using AutoMapper;
using CMS.Application.Common;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Entities;
using CMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<IdentityRepository> _logger;
        public IdentityRepository(UserManager<ApplicationUser> userManager, IMapper mapper, ILogger<IdentityRepository> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<User?> Resgister(User user, string password)
        {


            //ApplicationUser createRequest = _mapper.Map<ApplicationUser>(user);
            ApplicationUser createRequest = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                IsClinicAccount = user.IsClinicAccount
            };
            _logger.LogInformation($"Before CreateAsync: Id={createRequest.Id}, Email={createRequest.Email}, UserName={createRequest.UserName}, Password={password}");
            IdentityResult CreateUser = await _userManager.CreateAsync(createRequest, password);
            _logger.LogInformation($"After CreateAsync: Success={CreateUser.Succeeded}, Id={createRequest.Id}");
            if (CreateUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(createRequest, "Clinic");
                var newUser = _mapper.Map<User>(createRequest);
                _logger.LogInformation("Completed registration for user with email: {Email}", user.Email);
                return newUser;
            }
            _logger.LogInformation("Failed to register user with email: {Email}. Errors: {Errors}", user.Email, string.Join(", ", CreateUser.Errors.Select(e => e.Description)));
            return null;


            //_logger.LogError(ex, "An error occurred while registering the user with email: {Email}", user.Email);

        }
    }
}

