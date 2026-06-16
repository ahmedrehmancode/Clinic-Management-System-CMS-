using CMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Infrastructre.Data;
using CMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CMS.Application.Interfaces.Repository;

namespace CMS.Infrastructure
{
    public static class DependencyInjection
    {
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
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[""]))
                    };
                }
                );
            services.AddScoped<IClinicRepository, ClinicRepository>();
            return services;
        }
    }
}
