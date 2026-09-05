using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class ProductGalleryConfiguration : IEntityTypeConfiguration<ProductGallery>
{
	public void Configure(EntityTypeBuilder<ProductGallery> builder)
	{
		builder.HasKey(i => i.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);

		builder.HasOne(i => i.Product)
			.WithMany(i => i.ProductGallery)
			.HasForeignKey(i => i.ProductId);

		builder.HasOne(i => i.File)
			.WithMany()
			.HasForeignKey(i => i.FileId);
	}
}
