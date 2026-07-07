using AspNetCoreGeneratedDocument;
using AutoMapper;
using CMS.Application.Features.Authentication.Register;

//using User = CMS_Clinic_Management_System_.Models.User;
//using CMS.Domain.Models;
//using CMS_Clinic_Management_System_.Migrations;
using CMS_Clinic_Management_System_.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;



namespace CMS_Clinic_Management_System_.Controllers
{

    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, IMapper mapper, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        //logout ACtion
        public IActionResult logout()
        {

            return View();
        }

        //user sign up View
        public IActionResult UserSignUp()
        {
            return View();
        }

        //user sign up HttpRequest

        [HttpPost]
        public async Task<IActionResult> UserSignUp(SignupViewModle model)
        {
            try
            {


                _logger.LogInformation("User SignUp Request Processed for Email: {Email}", model.Email);

                var Data = _mapper.Map<RegisterCommand>(model);

                var result = await _mediator.Send(Data);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.Message!);
                    return View(model);
                }


                _logger.LogInformation("User SignUp Request Received for Email: {Email}", model.Email);


                return RedirectToAction("UserLogin");
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    Console.WriteLine($"{error.PropertyName}: Error: {error.ErrorMessage}");
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }

        }



        //Forgotpassowrd View
        public IActionResult ForgotPassword()
        {
            return View();


        }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            return View();

        }
        //conform password action
        public IActionResult ChangePassword(int id)
        {

            return View();
        }


        [HttpPost]
        public IActionResult ChangePassword(int id, string password, string conformpassword)
        {

            return RedirectToAction();
        }
        //userlogin view
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(string Email, string Password)
        {

            return RedirectToAction();
        }

    }
}

