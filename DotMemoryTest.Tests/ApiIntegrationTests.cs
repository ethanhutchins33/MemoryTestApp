using System.Net;
using System.Security.Cryptography;

namespace DotMemoryTest.Tests;

public class ApiIntegrationTests : IDisposable
{
    private IntegrationTestWebApplicationFactory _factory;
    private HttpClient _client;

    [OneTimeSetUp]
    public void OneTimeSetup() => _factory = new IntegrationTestWebApplicationFactory();

    [SetUp]
    public void Setup() => _client = _factory.CreateClient();

    [Test]
    public async Task Should_ReturnHttp200_When_PostBigString()
    {
        const int arrayLength = 1024 * 1024 * 100;
        var bytes = new byte[arrayLength];
        RandomNumberGenerator.Fill(bytes);
        var myString = System.Text.Encoding.Default.GetString(bytes);

        var result = await _client.PostAsJsonAsync(new Uri("https://localhost:7121/weatherforecast"), myString);

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task Should_ReturnHttp200_When_Get()
    {
        var result = await _client.GetAsync("https://localhost:7121/weatherforecast");

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    public void Dispose() => _factory?.Dispose();
}
