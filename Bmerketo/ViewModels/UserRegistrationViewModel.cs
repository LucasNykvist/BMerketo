using System.ComponentModel.DataAnnotations;
using Bmerketo.Models.Identity;

namespace Bmerketo.ViewModels
{
	public class UserRegistrationViewModel
	{
		[Display(Name = "First Name")]
		[Required(ErrorMessage = "First Name is required")]
		public string FirstName { get; set; } = null!;

		[Display(Name = "Last Name")]
		[Required(ErrorMessage = "Last Name is required")]
		public string LastName { get; set; } = null!;

		[Display(Name = "E-mail Address")]
		[Required(ErrorMessage = "E-mail is required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = null!;

		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Display(Name = "Confirm Password")]
		[Required(ErrorMessage = "Password is required")]
		[Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
		public string ConfirmPassword { get; set; } = null!;

		[Display(Name = "Street name")]
		public string StreetName { get; set; } = null!;

		[Display(Name = "Postal code")]
		public string PostalCode { get; set; } = null!;

		[Display(Name = "City")]
		public string City { get; set; } = null!;

		public static implicit operator CustomIdentityUser(UserRegistrationViewModel viewModel)
		{
			return new CustomIdentityUser
			{
				UserName = viewModel.Email,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
			};
		}
	}
}

