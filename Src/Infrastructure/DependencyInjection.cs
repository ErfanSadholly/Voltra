using Application.IRepositories;
using Application.IServices;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.AuthorizationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
	public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<MainDbContext>((provider, option) =>
		{
			option.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					option => option.CommandTimeout(100));

			option.AddInterceptors(provider.GetRequiredService<AuditSaveChangesInterceptor>());
		});

		services.AddDataProtection()
			.PersistKeysToFileSystem(new DirectoryInfo(configuration["ProtectionKey:Address"]!));

		services.AddHttpContextAccessor();

		services.AddScoped<ICurrentUserService, CurrentUserService>();
		services.AddScoped<IDataProtectionService, DataProtectionService>();
		services.AddScoped<AuditSaveChangesInterceptor>();
		services.AddScoped<IPermissionSyncService, PermissionSyncService>();
		services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
		services.AddScoped<ISettingRepository, SettingRepository>();
		services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IBrandRepository, BrandRepository>();
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
		services.AddScoped<AppControllerRepository>();
		services.AddScoped<AppPermissionRepository>();
		services.AddScoped<AppRolePermissionRepository>();
		services.AddScoped<IFileUploadRepository, FileUploadRepository>();
		services.AddScoped<IProductGalleryRepository, ProductGalleryRepository>();
		services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
		services.AddScoped<IProductInventoryRepository, ProductInventoryRepository>();
	}
}
