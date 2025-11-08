using FluentValidation;
using Market.Application.Modules.Identity.Users.Commands;

namespace Market.Application.Modules.Identity.Users.Validations
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
