using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

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
				if(await _productService.CreateAsync(viewModel))
				{
					return RedirectToAction("Index", "Products");
				}

				ModelState.AddModelError("", "Something went wrong when creating product");

			}
			return View();
		}
	}
}
