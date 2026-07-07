using AutoMapper;
using CMS.Application.Common;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterHandler> _logger;

        public RegisterHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper, ILogger<RegisterHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("RegisterHandler: Handling RegisterCommand for Email: {Email}", request.Email);
            var ExestingEmail = await _unitOfWork.User.GetByEmail(request.Email);
            if (ExestingEmail != null) return Result.Failure("Email Already Exits");

            var newUser = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.ClinicName,
                IsClinicAccount = true,
                PhoneNumber = request.Phone
            };

            var createdUser = await _unitOfWork.Identity.Resgister(newUser, request.Password);
            Console.WriteLine("Created User: " + createdUser?.Email);
            Console.WriteLine("Created User ID: " + createdUser?.Id);
            Console.WriteLine("Created User Name: " + createdUser?.UserName);
            Console.WriteLine("Created User Email: " + createdUser?.Email);
            Console.WriteLine("Created User PhoneNumber: " + createdUser?.PhoneNumber);
            Console.WriteLine("created user is clinic account: " + createdUser?.IsClinicAccount);
            if (createdUser == null) return Result.Failure("Failed to register user");
            Clinic newClinic = _mapper.Map<Clinic>(request);
            newClinic.UserId = createdUser.Id!;
            var clinic = _unitOfWork.Clinic.CreateAsync(newClinic);
            await _unitOfWork.SaveAsync();
            if(clinic == null) return Result.Failure("Failed to create clinic");

            return Result.Success("User Registered Successfully");
        }
    }
}