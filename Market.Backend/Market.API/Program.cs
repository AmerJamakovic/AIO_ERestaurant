using Market.API;
using Market.Application;
using Market.Domain.Entities.Identity;
using Market.Infrastructure;
using Microsoft.AspNetCore.Identity;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Registrations by layers
        builder
            .Services.AddAPI(builder.Configuration, builder.Environment)
            .AddInfrastructure(builder.Configuration, builder.Environment)
            .AddApplication();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var hasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<Customer>>();

            // LOZINKA koju želite da hashirate (isto kao u Swaggeru: "Muhamed2016!")
            const string rawPassword = "Muhamed2016!";

            // Kreiranje hasha
            var testUser = new Customer
            {
                FirstName = "Muhamed",
                LastName = "DFGUHDSU",
                Email = "dd",
                PasswordHash = rawPassword,

            }; // Morate proslijediti instancu korisnika
            var hashedPassword = hasher.HashPassword(testUser, rawPassword);

            // ISPIS HASHA U KONZOLU
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"Raw Password: {rawPassword}");
            Console.WriteLine($"GENERATED HASH: {hashedPassword}");
            Console.WriteLine("--------------------------------------------------------------------------");
        }


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
