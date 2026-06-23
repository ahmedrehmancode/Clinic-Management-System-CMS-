using CMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Data
{
    public static class AdminAddSeeder
    {
        public static async Task AdminRegister(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //Array
            //string[] Role = { "Admin", "Clinic" };
            var admin = new ApplicationUser
            {
                UserName = "ahmed@gmail.com",
                FullName = "Ahmed Rehman",
                Email = "ahmed@gmail.com",
                PhoneNumber = "03160263293",
                IsClinicAccount = true,

            };
            string password = "Ahmed@123123";

                var result = await userManager.CreateAsync(admin, password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"{error} : {error.Description}");
                    
                    }
                                 
                }
            else { 
            
                  var NewAdmin =  await userManager.AddToRoleAsync(admin, "Admin");
            }

        }

    }
}

