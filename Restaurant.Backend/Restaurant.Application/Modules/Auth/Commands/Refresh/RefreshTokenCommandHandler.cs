namespace Restaurant.Application.Modules.Auth.Commands.Refresh;

public sealed class RefreshTokenCommandHandler(
    IAppDbContext ctx,
    IJwtTokenService jwt,
    TimeProvider timeProvider
) : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandDto>
{
    public async Task<RefreshTokenCommandDto> Handle(
        RefreshTokenCommand request,
        CancellationToken ct
    )
    {
        var incomingHash = jwt.HashRefreshToken(request.RefreshToken);

        var rt = await ctx
            .RefreshTokens.Include(x => x.Customer)
            .FirstOrDefaultAsync(
                x => x.TokenHash == incomingHash && !x.IsRevoked && !x.IsDeleted,
                ct
            );

        var nowUtc = timeProvider.GetUtcNow().UtcDateTime;

        if (rt is null || rt.ExpiresAtUtc <= nowUtc)
            throw new RestaurantConflictException("Refresh token not valid or expired.");

        if (
            rt.Fingerprint is not null
            && request.Fingerprint is not null
            && rt.Fingerprint != request.Fingerprint
        )
        {
            throw new RestaurantConflictException("Invalid client fingerprint.");
        }

        var user = rt.Customer;
        if (user is null || !user.IsActive || user.IsDeleted)
            throw new RestaurantConflictException("User account is invalid.");

        rt.IsRevoked = true;
        rt.RevokedAtUtc = nowUtc;

        var pair = jwt.IssueTokens(user);

        var newRt = new RefreshTokenEntity
        {
            TokenHash = pair.RefreshTokenHash,
            ExpiresAtUtc = pair.RefreshTokenExpiresAtUtc,
            UserId = user.Id,
            Fingerprint = request.Fingerprint,
        };

        ctx.RefreshTokens.Add(newRt);
        await ctx.SaveChangesAsync(ct);

        return new RefreshTokenCommandDto
        {
            AccessToken = pair.AccessToken,
            RefreshToken = pair.RefreshTokenRaw,
            AccessTokenExpiresAtUtc = pair.AccessTokenExpiresAtUtc,
            RefreshTokenExpiresAtUtc = pair.RefreshTokenExpiresAtUtc,
        };
    }
}
