using Backend.Application.Shared;
using static Backend.Application.Orders.Commands.CreateOrderCommand;

namespace Backend.Application.Orders.Commands;

public record CreateOrderCommand(Guid CustomerId, List<CreateOrderItemDto> Items) : IRequest<CreateOrderResult>
{
    public record CreateOrderItemDto(Guid ProductId, int Quantity);
}
