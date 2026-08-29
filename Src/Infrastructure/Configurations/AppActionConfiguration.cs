using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class AppActionConfiguration : IEntityTypeConfiguration<AppAction>
{
	public void Configure(EntityTypeBuilder<AppAction> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Controller)
			.WithMany(i => i.Actions)
			.HasForeignKey(i => i.ControllerId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(i => new
		{
			i.ControllerId,
			i.Name
		}).IsUnique()
		.HasFilter("[IsDeleted] = 0");
	}
}
