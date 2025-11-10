using Restaurant.Application.Abstractions;
using Restaurant.Domain.Entities.PaymentProcessing;
using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    // Identity entities
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DbSet<UserFavorite> UserFavorites => Set<UserFavorite>();

    // Catalog entities
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<MenuGroup> MenuGroups => Set<MenuGroup>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<MenuItemIngredient> MenuItemsIngredients => Set<MenuItemIngredient>();
    public DbSet<RestaurantTable> RestaurantTables => Set<RestaurantTable>();

    // Payment processing entities
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    // Miscellaneous entities
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<PromoCode> PromoCodes => Set<PromoCode>();
    public DbSet<Review> Reviews => Set<Review>();

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }
}
