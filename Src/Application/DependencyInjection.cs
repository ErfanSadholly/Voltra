using Application.Features;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
        services.AddValidatorsFromAssemblyContaining<User_Register_Validator>();

        services.AddScoped<IUserFeature, UserFeature>();
        services.AddScoped<IRoleFeature, RoleFeature>();
        services.AddScoped<IUserRoleFeature, UserRoleFeature>();
        services.AddScoped<IAuthFeature, AuthFeature>();
        services.AddScoped<ISettingFeature, SettingFeature>();
        services.AddScoped<IProductFeature, ProductFeature>();
    }
}