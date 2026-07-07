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
            CreateMap<Clinic, User>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Clinic,RegisterCommand>().ReverseMap();
        }
    }
}
