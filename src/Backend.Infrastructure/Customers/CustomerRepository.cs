using Backend.Domain.Customers;
using Backend.Infrastructure.Shared;

namespace Backend.Infrastructure.Customers;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(BackendContext context) : base(context)
    {
    }
}
