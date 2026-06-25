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
    public class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            CreateMap<Clinic,User>().ReverseMap();
            CreateMap<Clinic,RegisterCommand>().ReverseMap();
        }
    }
}
