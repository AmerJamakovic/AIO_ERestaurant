using Market.Application.Abstractions;
using Market.Domain.Entities.Catalog;
using MediatR;

namespace Market.Application.Modules.Catalog.Products.Commands.Create
{
    public class CreateMenuItemHandlerCommand : IRequestHandler<CreateMenuItemCommand, MenuItem>
    {
        private readonly IAppDbContext _db;

        public CreateMenuItemHandlerCommand(IAppDbContext db) => _db = db;

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
                GroupId = request.GroupId,
            };
            _db.MenuItems.Add(menuItem);
            await _db.SaveChangesAsync(cancellationToken);
            return menuItem;
        }
    }
}
