using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category : BaseEntity<int>
{
	[MaxLength(128)]
	public required string Name { get; set; }
	public int? ParentId { get; set; }
	public Category? Parent { get; set; }
	public ICollection<Category> Children { get; set; } = new List<Category>();
}
