using Backend.Application.Shared;
using Backend.Domain.Orders;

namespace Backend.Application.Orders.Commands.CancelOrder;

public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, CancelOrderResult>
{
    private readonly IOrderRepository orderRepository;
    public CancelOrderHandler(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task<Result<CancelOrderResult>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await orderRepository.GetById(request.Id, cancellationToken);
        if (order is null)
        {
            return Error.NotFound("Order not found.");
        }
        order.Cancel();
        await orderRepository.Update(order, cancellationToken);
        return new CancelOrderResult();
    }
}