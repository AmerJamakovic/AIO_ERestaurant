namespace Market.Application.Abstractions;

// Application layer
using Market.Domain.Entities.Catalog;
using Market.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

public interface IAppDbContext
{
    // Catalog
    DbSet<MenuItem> MenuItems { get; }
    DbSet<MenuGroup> MenuGroups { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<RestaurantTable> RestaurantTables { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<PromoCode> PromoCodes { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Inventory> Inventories { get; }
    DbSet<Ingredient> Ingredients { get; }
    
    // Backwards-compatible Product entities (some Application modules still use these)
    DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<ProductEntity> Products { get; }

    // Identity
    DbSet<User> Users { get; }
    DbSet<Employee> Employees { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }
    DbSet<UserFavorite> UserFavorites { get; }
    
    // Legacy-styled users used by some Application modules
    DbSet<MarketUserEntity> MarketUsers { get; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}
