using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services
{
	public class AuthService
	{

		private readonly UserManager<CustomIdentityUser> _userManager;
		private readonly IdentityContext _identityContext;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SeedService _seedService;

		public AuthService(UserManager<CustomIdentityUser> userManager, IdentityContext identityContext, SeedService service, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_identityContext = identityContext;
			_seedService = service;
			_roleManager = roleManager;
		}

		public async Task<bool> SignUpAsync(UserRegistrationViewModel viewModel)
		{
			try
			{
				await _seedService.SeedRoles();
				var roleName = "user";

				if (!await _userManager.Users.AnyAsync())
					roleName = "admin";


				CustomIdentityUser customIdentityUser = viewModel;
				await _userManager.CreateAsync(customIdentityUser, viewModel.Password);
				await _userManager.AddToRoleAsync(customIdentityUser, roleName);


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
