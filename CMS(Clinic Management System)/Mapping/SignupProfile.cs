using AutoMapper;
using CMS.Application.Features.Authentication.Register;
using CMS_Clinic_Management_System_.ViewModels;

namespace CMS_Clinic_Management_System_.Mapping
{
    public class SignupProfile : Profile
    {
        public SignupProfile()
        {
            CreateMap<RegisterCommand,SignupViewModle>().ReverseMap();
        }
    }
}
