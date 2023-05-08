using Bmerketo.Contexts;
using Bmerketo.Models;
using Bmerketo.Models.Entities;
using Bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services
{
	public class ProductService
	{
		private readonly IdentityContext _context;

		public ProductService(IdentityContext context) { _context = context; }

		public async Task<bool> CreateAsync(ProductRegistrationViewModel viewModel)
		{
			try 
			{
				ProductEntity productEntity = viewModel;

				_context.Products.Add(productEntity);

				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<IEnumerable<ProductModel>> GetAllAsync()
		{
			var products = new List<ProductModel>();
			var items = await _context.Products.ToListAsync();
			foreach (var item in items)
			{
				ProductModel productModel = item;
				products.Add(productModel);
			}

			return products;
		}
	}
}
