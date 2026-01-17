using Backend.Api.Shared.Extensions;
using Backend.Application.Orders.Commands;
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
}
