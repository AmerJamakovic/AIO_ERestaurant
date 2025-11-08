using Restaurant.Application.Modules.Auth.Commands.Login;
using Restaurant.Application.Modules.Auth.Commands.Logout;
using Restaurant.Application.Modules.Auth.Commands.Refresh;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginCommandDto>> Login(
        [FromBody] LoginCommand command,
        CancellationToken ct
    )
    {
        return Ok(await _mediator.Send(command, ct));
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginCommandDto>> Refresh(
        [FromBody] RefreshTokenCommand command,
        CancellationToken ct
    )
    {
        return Ok(await _mediator.Send(command, ct));
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task Logout([FromBody] LogoutCommand command, CancellationToken ct)
    {
        await _mediator.Send(command, ct);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> Register(
        [FromBody] Restaurant.Application.Modules.Identity.Users.Commands.RegisterUserCommand command,
        CancellationToken ct
    )
    {
        var token = await _mediator.Send(command, ct);
        return Ok(token);
    }

    [HttpPost("user-login")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> UserLogin(
        [FromBody] Restaurant.Application.Modules.Identity.Users.Commands.LoginUserCommand command,
        CancellationToken ct
    )
    {
        var token = await _mediator.Send(command, ct);
        return Ok(token);
    }
}
