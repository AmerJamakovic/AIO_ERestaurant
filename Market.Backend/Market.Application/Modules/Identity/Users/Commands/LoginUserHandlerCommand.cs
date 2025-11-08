namespace Market.Application.Modules.Identity.Users.Commands
{
    public class LoginUserHandlerCommand : IRequestHandler<LoginUserCommand, JwtTokenPair>
    {
        private readonly IAppDbContext _db;
        private readonly IJwtTokenService _jwtService;
        private readonly IPasswordHasher<Market.Domain.Entities.Identity.Customer> _passwordHasher;

        public LoginUserHandlerCommand(
            IAppDbContext db,
            IJwtTokenService jwtService,
            IPasswordHasher<Market.Domain.Entities.Identity.Customer> passwordHasher
        )
        {
            _db = db;
            _jwtService = jwtService;
            _passwordHasher =
                passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<JwtTokenPair> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _db.Customers.FirstOrDefaultAsync(
                u => u.Email == request.UsernameOrEmail,
                cancellationToken
            );

            if (user == null)
                throw new UnauthorizedException("Invalid credentials");

            var verificationResult = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password
            );

            if (verificationResult == PasswordVerificationResult.Failed)
                throw new UnauthorizedException("Invalid credentials");

            return _jwtService.IssueTokens(user);
        }
    }
}
