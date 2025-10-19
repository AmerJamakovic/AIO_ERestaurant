using System.Linq.Expressions;
using Market.Domain.Common;
using Market.Infrastructure.Database.Seeders;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext
{
    private void ModifyTimestamps()
    {
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            var entity = ((BaseEntity)entry.Entity);

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        configurationBuilder.Properties<decimal?>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ApplyGlobalFilters(modelBuilder);

        StaticDataSeeder.Seed(modelBuilder); // static data
    }

    private void ApplyGlobalFilters(ModelBuilder modelBuilder)
    {
        // Apply a global filter to all entities inheriting from BaseEntity
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                // Build a typed lambda: (TEntity e) => !e.IsDeleted
                var clrType = entityType.ClrType;
                var parameter = Expression.Parameter(clrType, "e");
                var prop = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var compare = Expression.Equal(prop, Expression.Constant(false));
                var lambda = Expression.Lambda(compare, parameter);

                // Use the non-generic Entity(Type) API and supply the lambda as a LambdaExpression
                modelBuilder.Entity(clrType).HasQueryFilter(lambda as LambdaExpression);
            }
        }
    }

    public override int SaveChanges()
    {
        ModifyTimestamps();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = new CancellationToken()
    )
    {
        ModifyTimestamps();

        return base.SaveChangesAsync(cancellationToken);
    }
}
