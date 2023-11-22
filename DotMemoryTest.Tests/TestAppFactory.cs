using Microsoft.AspNetCore.Mvc.Testing;

namespace DotMemoryTest.Tests;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((host, configurationBuilder) =>
        {

        });
    }

}
