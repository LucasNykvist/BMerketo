using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services
{
	public class UserService
	{
		private readonly IdentityContext _context;

		public UserService(IdentityContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<CustomIdentityUser>> GetAllUsersAsync()
		{
			var users = new List<CustomIdentityUser>();
			var items = await _context.Users.ToListAsync();
			foreach (var item in items)
			{
				CustomIdentityUser user = item;
				users.Add(user);
			}

			return users;
		}
	}
}
