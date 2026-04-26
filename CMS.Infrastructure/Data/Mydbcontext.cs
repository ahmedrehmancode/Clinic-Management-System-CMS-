using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using CMS.Domain.Models;
namespace CMS.Infrastructre.Models
{
    public class Mydbcontext : DbContext

    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ClinicDetail> clinicDetails { get; set; }
        public DbSet<User> UsersDetails { get; set; }

        public DbSet<Category> Categories { get; set; }    

    }
}
