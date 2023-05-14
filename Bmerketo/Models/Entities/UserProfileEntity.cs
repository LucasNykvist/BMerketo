using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bmerketo.Models.Identity;

namespace Bmerketo.Models.Entities
{
	public class UserProfileEntity
	{
		[Key, ForeignKey("User")]
		public string UserID { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? StreetName { get; set; } = null!;
		public string? City { get; set; } = null!;
		public string?PostalCode { get; set; } = null!;

		public CustomIdentityUser User { get; set; } = null!;
	}
}
