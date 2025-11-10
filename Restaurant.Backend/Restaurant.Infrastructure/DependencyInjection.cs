using Restaurant.Application.Abstractions;
using Restaurant.Infrastructure.Common;
using Restaurant.Infrastructure.Database;
using Restaurant.Shared.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Restaurant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment env
    )
    {
        services
            .AddOptions<ConnectionStringsOptions>()
            .Bind(configuration.GetSection(ConnectionStringsOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddDbContext<DatabaseContext>(
            (sp, options) =>
            {
                if (env.IsEnvironment("IntegrationTests") || env.IsEnvironment("Testing"))
                {
                    options.UseInMemoryDatabase("IntegrationTestsDb");

                    return;
                }

                var cs = sp.GetRequiredService<IOptions<ConnectionStringsOptions>>().Value.Main;
                options.UseSqlServer(cs);
            }
        );

        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<DatabaseContext>());

        _ = services.AddScoped<IPasswordHasher<Customer>, PasswordHasher<Customer>>();

        services.AddTransient<IJwtTokenService, JwtTokenService>();

        services.AddHttpContextAccessor();

        services.AddSingleton<TimeProvider>(TimeProvider.System);

        return services;
    }
}
