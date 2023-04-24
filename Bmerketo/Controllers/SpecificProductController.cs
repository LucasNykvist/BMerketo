using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class SpecificProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Product ID";
            return View();
        }
    }
}
