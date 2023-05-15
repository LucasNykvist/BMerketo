using Bmerketo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ProductService _productService;

        public DetailsController(ProductService productService)
        {
            _productService = productService;
        }

        [Route("detailed/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var product = await _productService.GetProductDetailsAsync(id);

            ViewData["Title"] = "Product";
            return View(product);
        }
    }
}
