using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts
{
	public class IdentityContext : IdentityDbContext<CustomIdentityUser>
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		public IdentityContext(DbContextOptions<IdentityContext> options, RoleManager<IdentityRole> roleManager) : base(options)
		{
			_roleManager = roleManager;
		}

		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<UserProfileEntity> UserProfiles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			if (!_roleManager.RoleExistsAsync("admin").Result)
				_roleManager.CreateAsync(new IdentityRole("admin")).Wait();

			if (! _roleManager.RoleExistsAsync("user").Result)
				 _roleManager.CreateAsync(new IdentityRole("user")).Wait();
		}
	}
}
