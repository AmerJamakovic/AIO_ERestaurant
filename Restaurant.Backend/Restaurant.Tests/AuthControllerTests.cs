using System.Net.Http.Json;
using Restaurant.Application.Modules.Identity.Users.Commands;

namespace Restaurant.Tests;

public class AuthControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Register_And_Login_ShouldReturnToken()
    {
        var register = new RegisterUserCommand
        {
            Username = "testuser1",
            Email = "testuser1@example.com",
            Password = "Test1234!"
        };
        var regResponse = await _client.PostAsJsonAsync("api/auth/register", register);
        regResponse.EnsureSuccessStatusCode();
        var regToken = await regResponse.Content.ReadAsStringAsync();
        Assert.False(string.IsNullOrWhiteSpace(regToken));

        var login = new LoginUserCommand
        {
            UsernameOrEmail = "testuser1",
            Password = "Test1234!"
        };
        var loginResponse = await _client.PostAsJsonAsync("api/auth/user-login", login);
        loginResponse.EnsureSuccessStatusCode();
        var loginToken = await loginResponse.Content.ReadAsStringAsync();
        Assert.False(string.IsNullOrWhiteSpace(loginToken));
    }
}
