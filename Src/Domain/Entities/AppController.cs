using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class AppController : BaseEntity<int>
{
	[MaxLength(128)]
	public required string Name { get; set; }
	[MaxLength(128)]
	public string? DisplayName { get; set; }
	public ICollection<AppAction> Actions { get; set; } = new List<AppAction>();
}
