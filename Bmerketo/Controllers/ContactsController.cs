using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
	public class ContactsController : Controller
	{
		private readonly ContactService _contactService;

		public ContactsController(ContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			ViewData["Title"] = "Contact";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ContactSubmitViewModel viewModel)
		{
			if(ModelState.IsValid)
			{
				if(await _contactService.SubmitContactAsync(viewModel))
					return RedirectToAction("Index", "Contacts");

				ModelState.AddModelError("", "Something Went Wrong");
			}

			return View(viewModel);
		}
	}
}
