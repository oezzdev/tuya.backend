using Backend.Api.Shared.Extensions;
using Backend.Application.Orders.Commands.CancelOrder;
using Backend.Application.Orders.Commands.CreateOrder;
using Backend.Application.Orders.Queries.GetOrderById;
using Backend.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Orders;

[Route("api/v1/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator mediator;

    public OrdersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateOrderResult>> CreateOrder(CreateOrderCommand request)
    {
        Result<CreateOrderResult> result = await mediator.Send<CreateOrderCommand, CreateOrderResult>(request);

        return result.Match(Ok, ResultsExtensions.HandleError);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetOrderByIdResult>> GetOrderById(Guid id)
    {
        Result<GetOrderByIdResult> result = await mediator.Send<GetOrderByIdQuery, GetOrderByIdResult>(new(id));

        return result.Match(Ok, ResultsExtensions.HandleError);
    }

    [HttpDelete]
    public async Task<ActionResult<CancelOrderResult>> CancelOrder(CancelOrderCommand request)
    {
        Result<CancelOrderResult> result = await mediator.Send<CancelOrderCommand, CancelOrderResult>(request);
        return result.Match(NoContent, ResultsExtensions.HandleError);
    }
}
