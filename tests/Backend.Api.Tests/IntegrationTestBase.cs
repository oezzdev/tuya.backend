using Backend.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Api.Tests;

public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;
    protected readonly IServiceProvider Services;

    public IntegrationTestBase(WebApplicationFactory<Program> factory)
    {
        Client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<BackendContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDatabase");
                });
            });
        }).CreateClient();

        Services = factory.Services;
    }

    protected async Task SeedDatabase(Action<BackendContext> seedAction)
    {
        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BackendContext>();

        seedAction(context);
        await context.SaveChangesAsync();
    }
}