using Audit.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

[AuditIgnore]
public class AuditLog
{
	public long Id { get; set; }
	public int? UserId { get; set; }
	[MaxLength(512)]
	public required string EntityName { get; set; }
	[MaxLength(128)]
	public required string EntityId { get; set; }
	[MaxLength(10)]
	public required string Action { get; set; }
	[MaxLength(4000)]
	public string? OldValue { get; set; }
	[MaxLength(4000)]
	public string? NewValue { get; set; }
	public DateTime CreatedOn { get; set; }
}
