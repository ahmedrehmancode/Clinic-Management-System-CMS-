using AutoMapper;
using CMS.Application.Features.Authentication.Register;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,RegisterCommand>().ReverseMap(); ;
            
        }

    }
}
