using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class MainDbContext : IdentityDbContext<User, Role, int>
{
	public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);
	}

	public DbSet<RefreshToken> RefreshTokens { get; set; }
	public DbSet<Setting> Settings { get; set; }
	public DbSet<ErrorLog> ErrorLogs { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Brand> Brands { get; set; }
	public DbSet<Category> Categories { get; set; }
}
