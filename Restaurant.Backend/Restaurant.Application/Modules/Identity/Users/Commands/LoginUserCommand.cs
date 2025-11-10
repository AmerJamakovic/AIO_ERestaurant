namespace Restaurant.Application.Modules.Identity.Users.Commands;

public class LoginUserCommand : IRequest<JwtTokenPair> // Returns JWT token
{
    public required string UsernameOrEmail { get; set; }
    public required string Password { get; set; }
}
