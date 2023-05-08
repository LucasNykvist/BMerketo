using System.ComponentModel.DataAnnotations;
using Bmerketo.Models.Entities;

namespace Bmerketo.ViewModels
{
	public class ProductRegistrationViewModel
	{
		[Display(Name= "Product Name *")]
		[Required(ErrorMessage = "Product Name Required")]
		public string Name { get; set; } = null!;

		[Display(Name = "Product Description *")]
		[Required(ErrorMessage = "Product Description Required")]
		public string Description { get; set; } = null!;

		[Display(Name = "Product Price *")]
		[Required(ErrorMessage = "Product Price Required")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Display(Name = "Product Image *")]
		[Required(ErrorMessage = "Product Image Required")]
		public string Image { get; set; } = null!;

		public static implicit operator ProductEntity(ProductRegistrationViewModel viewModel)
		{
			return new ProductEntity
			{
				Name = viewModel.Name,
				Description = viewModel.Description,
				Price = viewModel.Price,
				Image = viewModel.Image
			};
		}
	}
}
