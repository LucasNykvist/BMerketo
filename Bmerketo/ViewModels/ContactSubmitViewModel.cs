using System.ComponentModel.DataAnnotations;
using Bmerketo.Models.Entities;

namespace Bmerketo.ViewModels
{
	public class ContactSubmitViewModel
	{
		[Display(Name = "Contact Name")]
		[Required(ErrorMessage = "Contact Name Required")]
		public string Name { get; set; } = null!;

		[Display(Name = "Contact Email")]
		[Required(ErrorMessage = "Contact Email Required")]
		public string Email { get; set; } = null!;

		[Display(Name = "Contact Phone Number")]
		[Required(ErrorMessage = "Contact Phone Number Required")]
		public string Phone { get; set; } = null!;

		[Display(Name = "Contact Company")]
		public string? Company { get; set; } = null!;

		[Display(Name = "Contact Comment")]
		[Required(ErrorMessage = "A Comment Is Required")]
		public string Comment { get; set; } = null!;

		public static implicit operator ContactEntity(ContactSubmitViewModel viewModel)
		{
			return new ContactEntity
			{
				Name = viewModel.Name,
				Email = viewModel.Email,
				Phone = viewModel.Phone,
				Company = viewModel.Company,
				Comment = viewModel.Comment,
			};
		}
	}
}
