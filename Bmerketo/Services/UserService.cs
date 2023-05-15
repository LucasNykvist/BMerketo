using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services
{
	public class UserService
	{
		private readonly IdentityContext _context;
		private readonly UserManager<CustomIdentityUser> _userManager;

		public UserService(IdentityContext context, UserManager<CustomIdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<IEnumerable<CustomIdentityUser>> GetAllUsersAsync()
		{
			var users = await _context.Users.ToListAsync();

			var usersWithRoles = new List<CustomIdentityUser>();

			foreach (var user in users)
			{
				var role = await _userManager.GetRolesAsync(user);

				user.Role = role.FirstOrDefault();

				usersWithRoles.Add(user);
			}

			return usersWithRoles;
		}


	}
}
