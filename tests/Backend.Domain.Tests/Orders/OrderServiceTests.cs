using Backend.Domain.Customers;
using Backend.Domain.Orders;
using Backend.Domain.Products;

namespace Backend.Domain.Tests.Orders;

public class OrderServiceTests
{
    [Fact]
    public void ProcessOrder_ShouldCreateOrderWithCorrectItemsAndTotalAmount()
    {
        // Arrange
        Customer customer = new("John Doe", "mail@example.com", "1234567890", "123 Main St");
        List<(Product, int)> products = new()
        {
            (new("Product A", 50.0m), 1),
            (new("Product B", 100.0m), 2)
        };
        OrderService orderService = new();
        // Act
        Order order = orderService.ProcessOrder(customer, products);
        // Assert
        Assert.Equal(customer, order.Customer);
        Assert.Equal(250.0m, order.TotalAmount);
        Assert.Equal(2, order.Items.Count);
    }

    [Fact]
    public void ProcessOrder_ShouldThrowException_WhenNoProductsProvided()
    {
        // Arrange
        Customer customer = new("John Doe", "mail@example.com", "1234567890", "123 Main St");
        List<(Product, int)> products = new()
        {
        };
        OrderService orderService = new();
        // Act
        ArgumentException exception = Assert.Throws<ArgumentException>(() => orderService.ProcessOrder(customer, products));
        // Assert
        Assert.NotNull(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void ProcessOrder_ShouldThrowException_WhenProductQuantityIsInvalid(int quantity)
    {
        // Arrange
        Customer customer = new("John Doe", "mail@example.com", "1234567890", "123 Main St");
        List<(Product, int)> products = new()
        {
            (new("Product A", 50.0m), quantity)
        };
        OrderService orderService = new();
        // Act
        ArgumentException exception = Assert.Throws<ArgumentException>(() => orderService.ProcessOrder(customer, products));
        // Assert
        Assert.NotNull(exception);
    }
}