using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities
{
	public class ContactEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string? Company { get; set; } = null!;
		public string Comment { get; set; } = null!;

	}
}
