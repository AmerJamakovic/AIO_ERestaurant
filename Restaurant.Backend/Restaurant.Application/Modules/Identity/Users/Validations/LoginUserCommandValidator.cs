using Restaurant.Application.Modules.Identity.Users.Commands;

namespace Restaurant.Application.Modules.Identity.Users.Validations;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.UsernameOrEmail).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
