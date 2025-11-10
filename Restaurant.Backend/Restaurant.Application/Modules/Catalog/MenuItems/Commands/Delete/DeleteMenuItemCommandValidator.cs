using Restaurant.Application.Modules.Catalog.Products.Commands.Delete;

namespace Restaurant.Application.Modules.Catalog.MenuItems.Commands.Delete;

public class DeleteMenuItemCommandValidator : AbstractValidator<DeleteMenuItemCommand>
{
    public DeleteMenuItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
