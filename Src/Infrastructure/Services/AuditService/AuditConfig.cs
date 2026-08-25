using Audit.Core;
using Domain.Entities;
using Infrastructure.Contexts;
using System.Text.Json;

namespace Infrastructure.Services.AuditService;

public static class AuditConfig
{

	private static readonly JsonSerializerOptions options = new JsonSerializerOptions
	{
		Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	};

	public static void Configure()
	{
		Configuration
			.Setup()
			.UseEntityFramework(ef => ef
			.AuditTypeMapper(_ => typeof(AuditLog))
			.AuditEntityAction<AuditLog>((ev, entry, auditLog) =>
			{
				auditLog.EntityName = entry.EntityType.Name;
				auditLog.EntityId = entry.PrimaryKey.First().Value?.ToString() ?? string.Empty;
				auditLog.Action = entry.Action;
				auditLog.CreatedOn = DateTime.Now;
				if (ev.CustomFields.TryGetValue("UserId", out var value) == true)
				{
					auditLog.UserId = int.TryParse(value?.ToString(), out var userId) ? userId : null;
				}

				var softDelete = entry.Changes != null
				&& entry.Changes.Any(i => i.ColumnName == "IsDeleted"
				&& i.OriginalValue is false
				&& i.NewValue is true);

				auditLog.Action = softDelete ? "Delete" : entry.Action;

				if (entry.Action == "Update" && entry.Changes != null)
				{
					var changes = entry.Changes.Where(x => x.OriginalValue != x.NewValue).ToList();

					auditLog.OldValue = JsonSerializer
					.Serialize(changes
					.ToDictionary(x => x.ColumnName, x => x.OriginalValue), options);

					auditLog.NewValue = JsonSerializer
					.Serialize(changes
					.ToDictionary(x => x.ColumnName, x => x.NewValue), options);
				}
			}).IgnoreMatchedProperties(true));
	}
}