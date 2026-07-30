using Domain;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;

namespace BattryShopApi.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(option =>
        {
            option.Password.RequireDigit = true;
            option.Password.RequiredLength = 7;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequireUppercase = false;
            option.Password.RequireLowercase = false;
            option.Password.RequiredUniqueChars = 0;
            option.User.RequireUniqueEmail = true;

        }).AddEntityFrameworkStores<MainDbContext>()
        .AddDefaultTokenProviders();
        return services;
    }
}