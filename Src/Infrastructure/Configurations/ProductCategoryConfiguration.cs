using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
	public void Configure(EntityTypeBuilder<ProductCategory> builder)
	{
		builder.HasKey(i => i.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder
			.HasIndex(i => new { i.ProductId, i.CategoryId })
			.IsUnique()
			.HasFilter("[IsDeleted] = 0");
	}
}
