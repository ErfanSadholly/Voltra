using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ProductProperty : BaseEntity<int>
{
	public int ProductId { get; set; }
	[MaxLength(256)]
	public required string Key { get; set; }
	[MaxLength(1024)]
	public required string Value { get; set; }
	public Product Product { get; set; } = null!;
}
