using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(i => i.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Parent)
			.WithMany(i => i.Children)
			.HasForeignKey(i => i.ParentId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
