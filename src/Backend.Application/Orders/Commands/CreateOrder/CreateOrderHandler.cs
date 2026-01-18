using Backend.Application.Shared;
using Backend.Domain.Customers;
using Backend.Domain.Orders;
using Backend.Domain.Products;

namespace Backend.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
{
    private readonly OrderService orderService;
    private readonly IOrderRepository orderRepository;
    private readonly ICustomerRepository customerRepository;
    private readonly IProductRepository productRepository;

    public CreateOrderHandler(OrderService orderService, IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
    {
        this.orderService = orderService;
        this.orderRepository = orderRepository;
        this.customerRepository = customerRepository;
        this.productRepository = productRepository;
    }

    public async Task<Result<CreateOrderResult>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetById(command.CustomerId, cancellationToken);
        if (customer is null)
        {
            return Error.Validation("Customer not found.");
        }
        List<Product> products = await productRepository.GetByIds(command.Items.Select(i => i.ProductId), cancellationToken);
        if (products.Count != command.Items.Count)
        {
            return Error.Validation("One or more products not found.");
        }

        IEnumerable<(Product, int)> items = command.Items
            .Select(i => (products.Single(p => p.Id == i.ProductId), i.Quantity));

        Order order = orderService.ProcessOrder(customer, items);
        await orderRepository.Add(order, cancellationToken);

        return new CreateOrderResult(order.Id);
    }
}
