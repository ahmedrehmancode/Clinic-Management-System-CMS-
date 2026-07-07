using CMS.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.ClinicName)
                .NotEmpty().WithMessage("Name Is Required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password Is Requried")
                .MinimumLength(6).WithMessage("Password Must have 6 characters")
                .MaximumLength(15).WithMessage("Passowrd Should less than 15 characters")
                .Matches("[A-Z]").WithMessage("Must Contain an  uppercase letter")
                .Matches("[a-z]").WithMessage("Must Contain an  lowercase letter")
                .Matches("[0-9]").WithMessage("Must Contain a digit")
                .Matches(@"[!@#$%^&*()_{}?/\\]").WithMessage("Must Contain an  Special character");
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email Is required")
               .EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword Is required")
                .Equal(x => x.Password).WithMessage("Password Do not Matched");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address Is requred");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone Is required")
                .MaximumLength(11).WithMessage("Phone Number Should be 11 digits");
            RuleFor(x => x.ClinicRegistraionNumber)
                .NotEmpty().WithMessage("ClinicRegistraionNumber Is required")
                .MaximumLength(8).WithMessage("ClinicRegistraionNumber Should be 8 digits")
                .MinimumLength(7).WithMessage("ClinicRegistraionNumber Is Invalid");
        }
    }
}
