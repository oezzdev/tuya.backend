using Backend.Application.Shared;
using static Backend.Application.Orders.Commands.CreateOrder.CreateOrderCommand;

namespace Backend.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid CustomerId, List<CreateOrderItemDto> Items) : IRequest<CreateOrderResult>
{
    public record CreateOrderItemDto(Guid ProductId, int Quantity);
}
