using Application.Features;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IUserFeature, UserFeature>();
        services.AddScoped<IRoleFeature, RoleFeature>();
        services.AddValidatorsFromAssemblyContaining<User_Register_Validator>();
    }
}