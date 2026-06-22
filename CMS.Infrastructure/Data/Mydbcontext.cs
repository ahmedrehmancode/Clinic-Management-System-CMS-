using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CMS.Infrastructure.Identity;
using CMS.Domain.Entities;
namespace CMS.Infrastructre.Data
{
    public class Mydbcontext : IdentityDbContext<ApplicationUser>

    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options)
        {

        }
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        //public DbSet<User> UsersDetails { get; set; }

        //public DbSet<Category> Categories { get; set; }    

    }
}
