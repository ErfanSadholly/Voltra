using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class AppRolePermissionConfiguration : IEntityTypeConfiguration<AppRolePermission>
{
	public void Configure(EntityTypeBuilder<AppRolePermission> builder)
	{
		builder.HasKey(i => i.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Role)
			.WithMany(i => i.RolePermissions)
			.HasForeignKey(i => i.RoleId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(i => i.Permission)
			.WithMany(i => i.RolePermissions)
			.HasForeignKey(i => i.PermissionId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(i => new
		{
			i.RoleId,
			i.PermissionId,
		}).IsUnique()
		.HasFilter("[IsDeleted] = 0");
	}
}
