using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Application.Modules.Catalog.Products.Commands.Create;

public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, MenuItem>
{
    private readonly IAppDbContext _db;

    public CreateMenuItemCommandHandler(IAppDbContext db) => _db = db;

    public async Task<MenuItem> Handle(
        CreateMenuItemCommand request,
        CancellationToken cancellationToken
    )
    {
        var menuItem = new MenuItem
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            MenuGroupId = request.MenuGroupId,
        };
        _db.MenuItems.Add(menuItem);
        await _db.SaveChangesAsync(cancellationToken);
        return menuItem;
    }
}
