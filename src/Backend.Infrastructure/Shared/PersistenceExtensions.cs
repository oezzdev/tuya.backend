using Backend.Domain.Customers;
using Backend.Domain.Orders;
using Backend.Domain.Products;
using Backend.Infrastructure.Customers;
using Backend.Infrastructure.Orders;
using Backend.Infrastructure.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure.Shared;

public static class PersistenceExtensions
{
    /// <summary>
    /// Registers persistence-related services and configures the database context for the accounting application.
    /// </summary>
    /// <remarks>This method configures the <see cref="BackendContext"/> to use a database and
    /// registers repository and unit of work services with scoped lifetimes. Ensure that the configuration contains a
    /// valid connection string named "Accounting".</remarks>
    /// <param name="services">The service collection to which the persistence services will be added. Must not be null.</param>
    /// <param name="configuration">The application configuration used to retrieve the database connection string. Must not be null.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance, allowing for method chaining.</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BackendContext>((options) =>
        {
            options.UseSqlite(configuration.GetConnectionString("Backend"));
        });

        return services
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>();
    }
}