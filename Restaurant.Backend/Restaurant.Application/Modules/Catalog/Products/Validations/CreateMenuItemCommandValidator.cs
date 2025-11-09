using Restaurant.Application.Modules.Catalog.Products.Commands.Create;

namespace Restaurant.Application.Modules.Catalog.Products.Validations
{
    public class CreateMenuItemCommandValidator : AbstractValidator<CreateMenuItemCommand>
    {
        public CreateMenuItemCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.MenuGroupId).MaximumLength(100);
        }
    }
}
