using Bmerketo.Models.Identity;
using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AuthService _auth;

		public RegisterController(AuthService auth)
		{
			_auth = auth;
		}

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Register";
            return View();
        }


		[HttpPost]
		public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
		{

            if(ModelState.IsValid)
            {
                if(await _auth.SignUpAsync(viewModel))
                    return RedirectToAction("Index", "Login");

                 ModelState.AddModelError("","A user with the same E-mail already exists");
            }

			return View(viewModel);
		}
	}
}
