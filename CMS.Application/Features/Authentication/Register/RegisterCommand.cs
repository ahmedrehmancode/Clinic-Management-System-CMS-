using AutoMapper.Configuration.Annotations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Register
{
    public class RegisterCommand : IRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
