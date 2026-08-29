using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class AppPermission : BaseEntity<int>
{
	public int ActionId { get; set; }
	[MaxLength(128)]
	public required string Name { get; set; }
	public AppAction Action { get; set; } = null!;
	public ICollection<AppRolePermission> RolePermissions { get; set; } = new List<AppRolePermission>();
}
