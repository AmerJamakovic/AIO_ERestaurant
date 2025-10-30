using Market.Application.Abstractions;
using Market.Domain.Entities.Catalog;
using MediatR;

namespace Market.Application.Modules.Catalog.Products.Commands.Delete
{
    public class DeleteMenuItemHandlerCommand : IRequestHandler<DeleteMenuItemCommand, bool>
    {
        private readonly IAppDbContext _db;

        public DeleteMenuItemHandlerCommand(IAppDbContext db) => _db = db;

        public async Task<bool> Handle(
            DeleteMenuItemCommand request,
            CancellationToken cancellationToken
        )
        {
            var menuItem = await _db.MenuItems.FindAsync(
                new object[] { request.Id },
                cancellationToken
            );
            if (menuItem == null)
                return false;
            _db.MenuItems.Remove(menuItem);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
