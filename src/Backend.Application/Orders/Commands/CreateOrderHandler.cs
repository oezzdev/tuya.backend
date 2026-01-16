using Backend.Application.Shared;
using Backend.Domain.Customers;
using Backend.Domain.Orders;
using Backend.Domain.Products;

namespace Backend.Application.Orders.Commands;

public class CreateOrderHandler(OrderService orderService, IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository) : IRequestHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<Result<CreateOrderResult>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetById(command.CustomerId, cancellationToken);
        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found.");
        }

        IEnumerable<Product> products = await productRepository.GetByIds(command.Items.Select(i => i.ProductId), cancellationToken);
        if (products.Count() != command.Items.Count())
        {
            throw new InvalidOperationException("Some products not found.");
        }

        IEnumerable<(Product, int)> items = command.Items
            .Select(i => (products.Single(p => p.Id == i.ProductId), i.Quantity));

        Order order = orderService.ProcessOrder(customer, items);
        await orderRepository.Add(order, cancellationToken);

        return new CreateOrderResult(order.Id);
    }
}
