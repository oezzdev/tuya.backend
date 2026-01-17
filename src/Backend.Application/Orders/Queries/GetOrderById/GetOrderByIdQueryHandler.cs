using Backend.Application.Shared;
using Backend.Domain.Orders;

namespace Backend.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResult>
{
    private readonly IOrderRepository orderRepository;
    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task<Result<GetOrderByIdResult>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order? order = await orderRepository.GetDetailed(request.Id, cancellationToken);
        if (order is null)
        {
            return Error.NotFound("Order not found.");
        }

        var result = new GetOrderByIdResult(order.Id, order.Customer!.Name, order.Date, order.TotalAmount);
        return result;
    }
}