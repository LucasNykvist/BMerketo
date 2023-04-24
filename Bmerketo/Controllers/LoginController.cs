﻿using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public LoginController(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel viewModel)
        {
          
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false); 
                if(result.Succeeded)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Incorrect email address or password");
                
            }

            return View();
        }
    }
}

