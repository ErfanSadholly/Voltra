using Application.IRepositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MainDbContext>(option =>
        {
            option.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    option => option.CommandTimeout(100));
        });

        services.AddHttpContextAccessor();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
