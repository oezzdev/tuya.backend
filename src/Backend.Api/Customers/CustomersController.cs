using Backend.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Customers;

[Route("api/v1/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomersController(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
