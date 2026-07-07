using CMS.Application.Common;
using CMS.Application.Features.Authentication.Register;
using CMS.Application.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Mediator
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly); });
            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssembly(Assembly.Load("CMS.Application"));
            //});
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(cfg => { }, typeof(UserProfile).Assembly);

            services.AddTransient(
                    typeof(IPipelineBehavior<,>),
                    typeof(ValidationBehavior<,>)
                );

            return services;
        
        }

    }
}
