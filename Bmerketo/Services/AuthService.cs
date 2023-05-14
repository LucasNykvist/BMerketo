using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo.Services
{
	public class AuthService
	{

		private readonly UserManager<CustomIdentityUser> _userManager;
		private readonly IdentityContext _identityContext;

		public AuthService(UserManager<CustomIdentityUser> userManager, IdentityContext identityContext)
		{
			_userManager = userManager;
			_identityContext = identityContext;
		}

		public async Task<bool> SignUpAsync(UserRegistrationViewModel viewModel)
		{
			try
			{
				CustomIdentityUser customIdentityUser = viewModel;
				await _userManager.CreateAsync(customIdentityUser, viewModel.Password);

				UserProfileEntity userProfileEntity = viewModel;
				userProfileEntity.UserID = customIdentityUser.Id;

				_identityContext.UserProfiles.Add(userProfileEntity);
				await _identityContext.SaveChangesAsync();

				return true;
			}

			catch
			{
				return false;
			}
		}
	}
}
