using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class AppPermissionConfiguration : IEntityTypeConfiguration<AppPermission>
{
	public void Configure(EntityTypeBuilder<AppPermission> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Action)
			.WithOne(i => i.Permission)
			.HasForeignKey<AppPermission>(i => i.ActionId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(i => i.ActionId)
			.IsUnique()
			.HasFilter("[IsDeleted] = 0");
	}
}
