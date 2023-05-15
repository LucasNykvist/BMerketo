using Microsoft.AspNetCore.Identity;

namespace Bmerketo.Models.Identity
{
	public class CustomIdentityUser : IdentityUser
	{
		[ProtectedPersonalData]
		public string FirstName { get; set; } = null!;

		[ProtectedPersonalData]
		public string LastName { get; set; } = null!;

		public string? Company { get; set; } = null!;

		[ProtectedPersonalData]
		public string PostalCode { get; set; } = null!;

		[ProtectedPersonalData]
		public string City { get; set; } = null!;

		[ProtectedPersonalData]
		public string StreetName { get; set; } = null!;

		public string? ProfileImageURL { get; set; } = null!;

		public string? Role { get; set; } = null!;	
	}
}
