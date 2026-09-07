using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductPropertyConfiguration : IEntityTypeConfiguration<ProductProperty>
{
	public void Configure(EntityTypeBuilder<ProductProperty> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Product)
			.WithMany(i => i.ProductProperties)
			.HasForeignKey(i => i.ProductId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
