using Market.Application.Abstractions;
using Market.Domain.Entities.Catalog;
using Market.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    // Catalog entities
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<MenuGroup> MenuGroups => Set<MenuGroup>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<RestaurantTable> RestaurantTables => Set<RestaurantTable>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<PromoCode> PromoCodes => Set<PromoCode>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    // Identity entities
    public DbSet<User> Users => Set<User>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DbSet<UserFavorite> UserFavorites => Set<UserFavorite>();

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }
}
