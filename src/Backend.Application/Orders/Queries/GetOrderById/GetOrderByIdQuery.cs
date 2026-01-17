using Backend.Application.Shared;

namespace Backend.Application.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : IRequest<GetOrderByIdResult>;
