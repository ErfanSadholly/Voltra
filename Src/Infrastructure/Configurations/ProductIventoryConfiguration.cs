using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class ProductIventoryConfiguration : IEntityTypeConfiguration<ProductIventory>
{
	public void Configure(EntityTypeBuilder<ProductIventory> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Product)
			.WithOne(i => i.ProductIventory)
			.HasForeignKey<ProductIventory>(i => i.ProductId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
