using AutoMapper.Configuration.Annotations;
using CMS.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Register
{
    public class RegisterCommand : IRequest<Result>
    {
        public string ClinicName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
        
        public string ClinicRegistraionNumber { get; set; }






    }
}
