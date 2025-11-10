using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Application.Modules.Catalog.Products.Commands.Update;

public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, MenuItem>
{
    private readonly IAppDbContext _db;

    public UpdateMenuItemCommandHandler(IAppDbContext db) => _db = db;

    public async Task<MenuItem> Handle(
        UpdateMenuItemCommand request,
        CancellationToken cancellationToken
    )
    {
        var menuItem = await _db.MenuItems.FindAsync(
            new object[] { request.Id },
            cancellationToken
        );
        if (menuItem == null)
            return null!;
        menuItem.Name = request.Name;
        menuItem.Description = request.Description;
        menuItem.Price = request.Price;
        menuItem.MenuGroupId = request.MenuGroupId;
        await _db.SaveChangesAsync(cancellationToken);
        return menuItem;
    }
}
