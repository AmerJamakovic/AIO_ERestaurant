using System.Net.Http.Json;
using Market.Application.Modules.Identity.Employees.Commands.Create;
using Market.Application.Modules.Identity.Employees.Commands.Delete;
using Market.Application.Modules.Identity.Employees.Commands.Update;
using Market.Domain.Common;
using Xunit;

namespace Market.Tests;

public class EmployeeControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public EmployeeControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Create_Update_Delete_Employee_Flow()
    {
        // Create
        var create = new CreateEmployeeCommand
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "Test1234!",
            JobTitle = Market.Domain.Common.JobTitleEnum.MANAGER,
        };
        var createResponse = await _client.PostAsJsonAsync("api/Employee", create);
        createResponse.EnsureSuccessStatusCode();
        var created = await createResponse.Content.ReadFromJsonAsync<dynamic>();
        Assert.NotNull(created);
        string id = created!.id;
        Assert.False(string.IsNullOrWhiteSpace(id));

        // Update
        var update = new UpdateEmployeeCommand
        {
            Id = id,
            JobTitle = Market.Domain.Common.JobTitleEnum.WAITER,
            BirthDate = System.DateTime.UtcNow.AddYears(-25),
            HireDate = System.DateTime.UtcNow.AddYears(-1),
            YearsOfExperience = 1,
        };
        var updateResponse = await _client.PutAsJsonAsync($"api/Employee/{id}", update);
        updateResponse.EnsureSuccessStatusCode();
        var updated = await updateResponse.Content.ReadAsStringAsync();
        Assert.False(string.IsNullOrWhiteSpace(updated));

        // Delete
        var deleteResponse = await _client.DeleteAsync($"api/Employee/{id}");
        Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }
}
