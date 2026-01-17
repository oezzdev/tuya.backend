namespace Backend.Application.Orders.Queries.GetOrderById;

public record GetOrderByIdResult(Guid Id, string CustomerName, DateTimeOffset OrderDate, decimal TotalAmount);