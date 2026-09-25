using Application.IServices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json;

namespace Infrastructure.Services;

public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
	private readonly IHttpContextService _httpContextService;

	public AuditSaveChangesInterceptor(IHttpContextService httpContextService)
	{
		_httpContextService = httpContextService;
	}

	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		var context = eventData.Context;
		if (context == null)
			return base.SavingChangesAsync(eventData, result, cancellationToken);

		var entries = context.ChangeTracker
			.Entries()
			.Where(i => i.State == EntityState.Added
			|| i.State == EntityState.Modified
			|| i.State == EntityState.Deleted)
			.ToList();

		foreach (var entry in entries)
		{
			if (entry.Entity is AuditLog)
				continue;

			if (entry.Entity is ErrorLog)
				continue;

			var auditLog = new AuditLog
			{
				Action = string.Empty,
				EntityName = entry.Metadata.ClrType.Name,
				UserId = _httpContextService.GetUserId(),
				CreatedOn = DateTime.Now,
			};

			if (entry.State == EntityState.Added)
			{
				var newValue = new Dictionary<string, object?>();
				foreach (var property in entry.Properties)
				{
					newValue[property.Metadata.Name] = property.CurrentValue;
				}

				auditLog.EntityId = null;
				auditLog.Action = "Insert";
				auditLog.NewValue = JsonSerializer.Serialize(newValue);

				context.Set<AuditLog>().Add(auditLog);
			}

			var entityId = entry.Property(entry.Metadata.FindPrimaryKey()!.Properties.First().Name).CurrentValue?.ToString();
			if (entry.State == EntityState.Modified)
			{
				var oldValue = new Dictionary<string, object?>();
				var newValue = new Dictionary<string, object?>();
				foreach (var property in entry.Properties)
				{
					if (!property.IsModified)
						continue;

					oldValue[property.Metadata.Name] = property.OriginalValue;
					newValue[property.Metadata.Name] = property.CurrentValue;
				}

				var isSoftDelete = false;
				if (entry.Metadata.FindProperty("IsDeleted") is not null)
				{
					isSoftDelete = entry.Property("IsDeleted").OriginalValue is false && entry.Property("IsDeleted").CurrentValue is true;
				}

				auditLog.EntityId = entityId;
				auditLog.OldValue = JsonSerializer.Serialize(oldValue);
				if (!isSoftDelete)
				{
					auditLog.Action = "Update";
					auditLog.NewValue = JsonSerializer.Serialize(newValue);
				}
				else
				{
					auditLog.Action = "Delete";
				}

				context.Set<AuditLog>().Add(auditLog);
			}

			if (entry.State == EntityState.Deleted)
			{
				var oldValue = new Dictionary<string, object?>();

				foreach (var property in entry.Properties)
				{
					oldValue[property.Metadata.Name] = property.OriginalValue;
				}

				auditLog.Action = "HardDelete";
				auditLog.EntityId = entityId;
				auditLog.OldValue = JsonSerializer.Serialize(oldValue);

				context.Set<AuditLog>().Add(auditLog);
			}
		}

		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}
}
