using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Application.Modules.Catalog.Products.Commands.Create
{
    public class CreateProductHandlerCommand : IRequestHandler<CreateProductCommand, MenuItem>
    {
        private readonly IAppDbContext _db;
        public CreateProductHandlerCommand(IAppDbContext db) => _db = db;

        public async Task<MenuItem> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var menuItem = new MenuItem
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                GroupId = request.GroupId
            };
            _db.MenuItems.Add(menuItem);
            await _db.SaveChangesAsync(cancellationToken);
            return menuItem;
        }
    }
}
