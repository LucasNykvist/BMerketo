using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
	public class Admin : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
