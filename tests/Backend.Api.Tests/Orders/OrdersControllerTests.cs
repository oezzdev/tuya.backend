using Backend.Application.Orders.Commands.CreateOrder;
using Backend.Domain.Customers;
using Backend.Domain.Products;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace Backend.Api.Tests.Orders;

public class OrdersControllerTests : IntegrationTestBase
{
    public OrdersControllerTests(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task Should_CreateOrder_Succesfully()
    {
        // Arrange
        Customer customer = new("John Doe", "mail@example.com", "1234567890", "123 Main St");
        List<Product> products = new()
        {
            new("Product 1", 10.0m),
            new("Product 2", 20.0m)
        };
        await SeedDatabase(context =>
        {
            context.Customers.Add(customer);
            context.Products.AddRange(products);
        });
        CreateOrderCommand request = new(customer.Id, products.Select(p => new CreateOrderCommand.CreateOrderItemDto(p.Id, 1)).ToList());
        // Act
        HttpResponseMessage result = await Client.PostAsJsonAsync("/api/v1/orders", request);
        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task Should_ReturnBadRequest_When_CreatingOrderWithInvalidCustomerId()
    {
        // Arrange
        List<Product> products = new()
        {
            new("Product 1", 10.0m),
            new("Product 2", 20.0m)
        };
        await SeedDatabase(context =>
        {
            context.Products.AddRange(products);
        });
        CreateOrderCommand request = new(Guid.NewGuid(), products.Select(p => new CreateOrderCommand.CreateOrderItemDto(p.Id, 1)).ToList());
        // Act
        HttpResponseMessage result = await Client.PostAsJsonAsync("/api/v1/orders", request);
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }
}
