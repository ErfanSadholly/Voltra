using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class AppControllerConfiguration : IEntityTypeConfiguration<AppController>
{
	public void Configure(EntityTypeBuilder<AppController> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasIndex(x => x.Name)
			.IsUnique()
			.HasFilter("[IsDeleted] = 0");
	}
}
