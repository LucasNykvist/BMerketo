using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts
{
	public class IdentityContext : IdentityDbContext<CustomIdentityUser>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{
		}

		public DbSet<ProductEntity> Products { get; set; }

		public DbSet<UserProfileEntity> UserProfiles { get; set; }

	}
}
