using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;

        public RegisterController(UserManager<CustomIdentityUser> userManager)
        {
            _userManager = userManager;
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

                if (await _userManager.FindByNameAsync(viewModel.Email) == null)
                {
                    var result = await _userManager.CreateAsync(viewModel, viewModel.Password);
                    if(result.Succeeded)
                        return RedirectToAction("Index", "Login");
                }

 
                   ModelState.AddModelError("","A user with the same E-mail already exists");
            }

			return View(viewModel);
		}
	}
}
