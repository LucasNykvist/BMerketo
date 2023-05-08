using System.ComponentModel.DataAnnotations;

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
		public string Price { get; set; } = null!;

		[Display(Name = "Product Image *")]
		[Required(ErrorMessage = "Product Image Required")]
		public string Image { get; set; } = null!;
	}
}
