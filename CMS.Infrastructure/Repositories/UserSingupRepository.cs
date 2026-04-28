using CMS.Application.Interfaces;
using CMS.Domain.Models;
using CMS.Infrastructre.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories
{
    public class UserSingupRepository : IUserSignupRepository
    {
        private readonly Mydbcontext _context;

        public UserSingupRepository(Mydbcontext context )
        {
            _context = context; 
        }
        public async Task<bool> RegisterAsync(User user,ClinicDetail clinic)
        {
            //var data = new List<Admin>();
            await _context.UsersDetails.AddAsync(user);
            await  _context.SaveChangesAsync();

            await _context.clinicDetails.AddAsync(clinic);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<User> GetByEmailAsync(string email) 
        {
            return await _context.UsersDetails.FirstOrDefaultAsync(e => e.UserEmail == email);
        
        
        
        
        
        }

        
    }
}
