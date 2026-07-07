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
        public required string ClinicName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPassword { get; set; }

        public required string Phone { get; set; }

        public required string Address { get; set; }
        
        public required string ClinicRegistraionNumber { get; set; }






    }
}
