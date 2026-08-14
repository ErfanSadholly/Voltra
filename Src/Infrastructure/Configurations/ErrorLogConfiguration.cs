using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
{
    public void Configure(EntityTypeBuilder<ErrorLog> builder)
    {
        builder.HasKey(i => i.Id);
    }
}
