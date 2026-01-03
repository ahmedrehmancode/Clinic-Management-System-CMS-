using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
namespace CMS_Clinic_Management_System_.Models
{
    public class Mydbcontext : DbContext

    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        
    }
}
