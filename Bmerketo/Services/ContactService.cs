using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.ViewModels;

namespace Bmerketo.Services
{
	public class ContactService
	{
		private readonly IdentityContext _context;

		public ContactService(IdentityContext context)
		{
			_context = context;
		}

		public async Task<bool> SubmitContactAsync(ContactSubmitViewModel viewModel)
		{
			try
			{
				ContactEntity contactEntity = viewModel;

				_context.ContactInformation.Add(contactEntity);

				await _context.SaveChangesAsync();
				return true;
			}
			catch 
			{
				return false;
			}
		}
	}
}
