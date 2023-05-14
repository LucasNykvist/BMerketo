﻿namespace Bmerketo.Models
{
	public class ProductModel
	{
		public int? Id { get; set; }
		public string? Name { get; set; } 
		public string? Description { get; set; } 
		public decimal? Price { get; set; }
		public string? Image { get; set; }
		public List<string>? Tags { get; set; }
	}
}
