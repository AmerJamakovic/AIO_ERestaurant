using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Entities.PaymentProcessing;
using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Application.Abstractions;

public interface IAppDbContext
{
    // Identity
    DbSet<Customer> Customers { get; }
    DbSet<Employee> Employees { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }
    DbSet<UserFavorite> UserFavorites { get; }

    // Catalog
    DbSet<Ingredient> Ingredients { get; }
    DbSet<MenuGroup> MenuGroups { get; }
    DbSet<MenuItem> MenuItems { get; }
    DbSet<MenuItemIngredient> MenuItemsIngredients { get; }
    DbSet<RestaurantTable> RestaurantTables { get; }

    // Payment processing
    DbSet<OrderItem> OrderItems { get; }
    DbSet<Order> Orders { get; }
    DbSet<Reservation> Reservations { get; }

    // Miscellaneous
    DbSet<Game> Games { get; }
    DbSet<Inventory> Inventories { get; }
    DbSet<Invoice> Invoices { get; }
    DbSet<PromoCode> PromoCodes { get; }
    DbSet<Review> Reviews { get; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}
