using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
{
	public void Configure(EntityTypeBuilder<ProductInventory> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Product)
			.WithOne(i => i.ProductInventory)
			.HasForeignKey<ProductInventory>(i => i.ProductId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
