using DotNetEnv;

using Restaurant.API;
using Restaurant.Application;
using Restaurant.Infrastructure;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Database connection string from environment variables
        Env.Load();

        string connectionString = $"Server={Env.GetString("DB_SERVER")};" + 
            $"Database={Env.GetString("DB_NAME")};" + 
            $"User Id={Env.GetString("DB_USER")};" + 
            $"Password={Env.GetString("DB_PASSWORD")};" +
            "TrustServerCertificate=True;Encrypt=False;MultipleActiveResultSets=true";
        
        builder.Configuration["ConnectionStrings:Main"] = connectionString;

        // Registrations by layers
        builder
            .Services.AddAPI(builder.Configuration, builder.Environment)
            .AddInfrastructure(builder.Configuration, builder.Environment)
            .AddApplication();

        var app = builder.Build();

        // Middleware pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        // Migracije + seeding (centralized in Infrastructure)
        await app.Services.InitializeDatabaseAsync(app.Environment);

        app.Run();
    }
}
