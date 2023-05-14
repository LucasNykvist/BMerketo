using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;

namespace Bmerketo.ViewModels
{
	public class UserRegistrationViewModel
	{
		[Display(Name = "First Name")]
		[Required(ErrorMessage = "First Name Is Required")]
		[RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Invalid First Name")]
		public string FirstName { get; set; } = null!;

		[Display(Name = "Last Name")]
		[Required(ErrorMessage = "Last Name Is Required")]
		[RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Invalid Last Name")]
		public string LastName { get; set; } = null!;

		[Display(Name = "E-mail Address")]
		[Required(ErrorMessage = "E-mail Is Required")]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid E-mail Address")]

		public string Email { get; set; } = null!;

		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Company")]
		public string? Company { get; set; } = null!;

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password must be atleast 8 characters long, Contain 1 uppercase and lowercase, 1 number and 1 special character such as £@$")]
		public string Password { get; set; } = null!;

		[Display(Name = "Confirm Password")]
		[Required(ErrorMessage = "Password Is Required")]
		[Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
		public string ConfirmPassword { get; set; } = null!;

		[Display(Name = "Street name")]
		[Required(ErrorMessage = "Steet Name Is Required")]
		public string StreetName { get; set; } = null!;

		[Display(Name = "Postal code")]
		[Required(ErrorMessage = "Postal Code Is Required")]
		public string PostalCode { get; set; } = null!;

		[Display(Name = "City")]
		[Required(ErrorMessage = "City Is Required")]
		public string City { get; set; } = null!;

		[Display(Name = "Profile Image")]
		public string? ProfileImageURL { get; set; }

		public static implicit operator CustomIdentityUser(UserRegistrationViewModel viewModel)
		{
			return new CustomIdentityUser
			{
				UserName = viewModel.Email,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				StreetName = viewModel.StreetName,
				PostalCode = viewModel.PostalCode,
				City = viewModel.City,
				ProfileImageURL = viewModel.ProfileImageURL,
			};
		}

		public static implicit operator UserProfileEntity(UserRegistrationViewModel viewModel)
		{
			return new UserProfileEntity
			{
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				StreetName = viewModel.StreetName,
				PostalCode = viewModel.PostalCode,
				City = viewModel.City,
			};
		}
	}
}

