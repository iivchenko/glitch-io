using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profile.Application.Common.Interfaces;
using Profile.Infra.Persistence;
using Profile.Infra.Services;

namespace Profile.Infra;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase")) // TODO: I don't like this, Refactor
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("glitch-profile"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), // TODO: I don't like it. Refactor
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<DevelopDbSeeder>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddTransient<IDateTimeService, DateTimeService>();

        return services;
    }
}

