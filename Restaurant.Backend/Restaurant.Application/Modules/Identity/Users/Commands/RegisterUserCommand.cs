namespace Restaurant.Application.Modules.Identity.Users.Commands
{
    public class RegisterUserCommand : IRequest<JwtTokenPair>
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
