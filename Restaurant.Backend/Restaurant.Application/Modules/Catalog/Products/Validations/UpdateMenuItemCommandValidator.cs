using Restaurant.Application.Modules.Catalog.Products.Commands.Update;

namespace Restaurant.Application.Modules.Catalog.Products.Validations
{
    public class UpdateMenuItemCommandValidator : AbstractValidator<UpdateMenuItemCommand>
    {
        public UpdateMenuItemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.GroupId).MaximumLength(100);
        }
    }
}
