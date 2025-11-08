using System.Net.Http.Json;
using Restaurant.Application.Modules.Catalog.Products.Commands.Create;
using Restaurant.Application.Modules.Catalog.Products.Commands.Update;

namespace Restaurant.Tests;

public class MenuItemControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public MenuItemControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Create_Update_Delete_MenuItem_Flow()
    {
        // Create
        var create = new CreateMenuItemCommand
        {
            Name = "Pizza Margherita",
            Description = "Classic pizza with tomato and cheese",
            Price = 10.99m,
            GroupId = "50",
        };
        var createResponse = await _client.PostAsJsonAsync("api/MenuItem", create);
        createResponse.EnsureSuccessStatusCode();
        var created = await createResponse.Content.ReadFromJsonAsync<dynamic>();
        Assert.NotNull(created);
        string id = created!.id;
        Assert.False(string.IsNullOrWhiteSpace(id));

        // Update
        var update = new UpdateMenuItemCommand
        {
            Id = id,
            Name = "Pizza Margherita Updated",
            Description = "Updated description",
            Price = 12.99m,
            GroupId = "12345",
        };
        var updateResponse = await _client.PutAsJsonAsync($"api/MenuItem/{id}", update);
        updateResponse.EnsureSuccessStatusCode();
        var updated = await updateResponse.Content.ReadAsStringAsync();
        Assert.Contains("Updated", updated);

        // Delete
        var deleteResponse = await _client.DeleteAsync($"api/MenuItem/{id}");
        Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }
}
