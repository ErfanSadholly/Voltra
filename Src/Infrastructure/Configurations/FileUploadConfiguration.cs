using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class FileUploadConfiguration : IEntityTypeConfiguration<FileUpload>
{
	public void Configure(EntityTypeBuilder<FileUpload> builder)
	{
		builder.HasKey(f => f.Id);
		builder.HasQueryFilter(i => i.IsDeleted == false);
	}
}
