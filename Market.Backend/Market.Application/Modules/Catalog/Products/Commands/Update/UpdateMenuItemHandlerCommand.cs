using Market.Application.Abstractions;
using Market.Domain.Entities.Catalog;
using MediatR;

namespace Market.Application.Modules.Catalog.Products.Commands.Update
{
    public class UpdateMenuItemHandlerCommand : IRequestHandler<UpdateMenuItemCommand, MenuItem>
    {
        private readonly IAppDbContext _db;

        public UpdateMenuItemHandlerCommand(IAppDbContext db) => _db = db;

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
            menuItem.GroupId = request.GroupId;
            await _db.SaveChangesAsync(cancellationToken);
            return menuItem;
        }
    }
}
