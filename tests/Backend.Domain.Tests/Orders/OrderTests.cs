using Backend.Domain.Orders;
using Backend.Domain.Products;

namespace Backend.Domain.Tests.Orders;

public class OrderTests
{
    [Fact]
    public void ConstructorShouldInitializeCorrectly()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var orderDate = DateTimeOffset.UtcNow;
        // Act
        var order = new Order(customerId);
        var now = DateTimeOffset.UtcNow;
        // Assert
        Assert.Equal(customerId, order.CustomerId);
        Assert.InRange(order.Date, orderDate, now);
        Assert.Empty(order.Items);
        Assert.Equal(OrderStatus.Pending, order.Status);
    }

    [Fact]
    public void TotalAmountShouldCalculateCorrectly()
    {
        // Arrange
        var order = new Order(Guid.NewGuid());
        var product1 = new Product("product/1", 10m);
        var product2 = new Product("product/2", 20m);
        var item1 = new OrderItem(order, product1, 2);
        var item2 = new OrderItem(order, product2, 3);
        order.Items.Add(item1);
        order.Items.Add(item2);
        // Act
        var totalAmount = order.TotalAmount;
        // Assert
        Assert.Equal(80m, totalAmount);
    }

    [Fact]
    public void AddItemShouldAddOrderItem()
    {
        // Arrange
        var order = new Order(Guid.NewGuid());
        var product = new Product("product/1", 15m);
        // Act
        order.AddItem(product, 1);
        // Assert
        Assert.Single(order.Items);
        Assert.Contains(product, order.Items.Select(x => x.Product));
    }
}
