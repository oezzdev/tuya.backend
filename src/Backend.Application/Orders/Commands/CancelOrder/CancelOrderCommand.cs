using Backend.Application.Shared;

namespace Backend.Application.Orders.Commands.CancelOrder;

public record CancelOrderCommand(Guid Id) : IRequest<CancelOrderResult>;
