using AutoMapper;
using CMS.Application.Common;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly IidentityRepository _identityRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;

        public RegisterHandler(
            IidentityRepository identityRepository,
            IUserRepository userRepository,
            IClinicRepository clinicRepository,
            IMapper mapper)
        {
            _identityRepository = identityRepository;
            _userRepository = userRepository;
            _clinicRepository = clinicRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var ExestingEmail = await _userRepository.GetByEmail(request.Email);
            if (ExestingEmail != null)  return Result.Failure("Email Already Exits");

            var newUser = _mapper.Map<Domain.Entities.User>(request);

           var createdUser = await _identityRepository.Resgister(newUser,request.Password);
            if(createdUser != null)
            {
                var clinic = _mapper.Map<Clinic>(createdUser);

                var newClinic = _clinicRepository.CreateAsync(clinic);
                if(newClinic == null) { return Result.Failure("Something Going Wrong"); }
            
            }

            return Result.Success();


            

        }
    }
}

