using Restaurant.Application.Modules.Catalog.Products.Commands.Delete;

namespace Restaurant.Application.Modules.Catalog.Products.Validations
{
    public class DeleteMenuItemCommandValidator : AbstractValidator<DeleteMenuItemCommand>
    {
        public DeleteMenuItemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
