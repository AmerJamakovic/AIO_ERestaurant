namespace Restaurant.Application.Modules.Catalog.Products.Commands.Delete
{
    public class DeleteProductHandlerCommand : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IAppDbContext _db;
        public DeleteProductHandlerCommand(IAppDbContext db) => _db = db;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var menuItem = await _db.MenuItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (menuItem == null) return false;
            _db.MenuItems.Remove(menuItem);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
