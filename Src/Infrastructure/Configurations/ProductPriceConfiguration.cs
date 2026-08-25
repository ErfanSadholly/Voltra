using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
{
	public void Configure(EntityTypeBuilder<ProductPrice> builder)
	{
		builder.HasKey(i => i.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder
			.Property(i => i.Price)
			.HasPrecision(18, 0);

		builder.HasOne(i => i.Product)
			.WithMany(i => i.ProductPrices)
			.HasForeignKey(i => i.ProductId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
