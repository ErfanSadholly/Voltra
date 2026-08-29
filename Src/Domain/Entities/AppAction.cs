using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class AppAction : BaseEntity<int>
{
	[MaxLength(128)]
	public required string Name { get; set; }
	public int ControllerId { get; set; }
	[MaxLength(128)]
	public string? DisplayName { get; set; }
	public AppController Controller { get; set; } = null!;
	public AppPermission Permission { get; set; } = null!;
}
