using FastLinker.API.Controllers;
using FastLinker.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FastLinker.ItegrationTest;

public class ShortenerTests
{
    private readonly ApiClie _apiClient;

    public ShortenerTests(ApiFixture _apiClient)
    {
        _apiClient = fixture.ApiClient;
    }

    [Fact]
    public async Task Can_Create_ShortKey_And_Get_Url()
    {
        // Arrange
        var request = new { Url = "https://example.com", Title = "Example" };

        // Act
        var createResponse = await _apiClient.PostAsync("/api/shorten", request);
        createResponse.EnsureSuccessStatusCode();

        var shortKey = await createResponse.Content.ReadAsStringAsync();

        // Assert
        shortKey.Should().NotBeNullOrEmpty();

        // Act
        var getUrlResponse = await _apiClient.GetAsync($"/api/expand/{shortKey}");
        getUrlResponse.EnsureSuccessStatusCode();

        var urlResult = await getUrlResponse.Content.ReadAsStringAsync();

        // Assert
        urlResult.Should().Be(request.Url);
    }
}

public class ApiFixture : IDisposable
{
    public ApiFixture()
    {
        // Set up the test environment, initialize the API client, etc.
        // For example, you can read configuration from appsettings.json here.
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var baseUri = configuration["ApiBaseUri"];
        ApiClient = new ApiClient(baseUri);
    }

    public ApiClient ApiClient { get; }

    public void Dispose()
    {
        // Clean up test environment if necessary
    }
}