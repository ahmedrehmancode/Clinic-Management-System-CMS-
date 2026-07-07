using CMS.Application;
using CMS.Application.Interfaces.Repository;
using CMS.Infrastructre.Data;
using CMS.Infrastructure.Data;
using CMS.Infrastructure.Identity;
using CMS.Infrastructure.Mapping;
using CMS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public static class DependencyInjection
    {
        // Seeding ke liye alag method
       public static async Task SeedRoleDatabaseAsync(this IServiceProvider serviceProvider)
        {
            var Scoped = serviceProvider.CreateScope();
            var roleManager = Scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DataSeeder.SeedRolesAsync(roleManager);

        }

        public static async Task SeedAdminAddAsync(this IServiceProvider serviceProvider)
        {

            var scoped = serviceProvider.CreateScope();
            var roleManager = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await AdminAddSeeder.AdminRegister(userManager, roleManager);
        
        
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
          

            // Database Connection
            services.AddDbContext<Mydbcontext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("mycon"));
            });
            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireUppercase = true;
                opt.Password.GetHashCode();
            }
            )
            .AddEntityFrameworkStores<Mydbcontext>()
            .AddDefaultTokenProviders();
            // AddAuthentication Middleware
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                option =>
                {
                    var key = configuration.GetValue<string>("Jwt:Key") ?? throw new InvalidOperationException("JWT key is not configured");
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT issuer is not configured"),
                        ValidAudience = configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT audience is not configured"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                }
                );
            services.AddAutoMapper(cfg => { }, typeof(IdentityProfile).Assembly);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IidentityRepository, IdentityRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
