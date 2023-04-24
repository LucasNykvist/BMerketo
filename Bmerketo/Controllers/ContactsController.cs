using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
	public class ContactsController : Controller
	{
		public IActionResult Index()
		{
			ViewData["Title"] = "Contacts";
			return View();
		}
	}
}
