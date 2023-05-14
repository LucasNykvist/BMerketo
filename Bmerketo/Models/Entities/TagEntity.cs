namespace Bmerketo.Models.Entities
{
	public class TagEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
	}
}
