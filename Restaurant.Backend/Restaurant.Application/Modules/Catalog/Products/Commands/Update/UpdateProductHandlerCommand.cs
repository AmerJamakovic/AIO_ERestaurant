using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Application.Modules.Catalog.Products.Commands.Update
{
    public class UpdateProductHandlerCommand : IRequestHandler<UpdateProductCommand, MenuItem>
    {
        private readonly IAppDbContext _db;

        public UpdateProductHandlerCommand(IAppDbContext db) => _db = db;

        public async Task<MenuItem> Handle(
            UpdateProductCommand request,
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
}
