using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]	
		public async Task<IActionResult> Register(ProductRegistrationViewModel viewModel)
		{
			if(ModelState.IsValid)
			{

			}
			return View();
		}
	}
}
