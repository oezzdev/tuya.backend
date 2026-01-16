namespace Backend.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetById(Guid id, CancellationToken cancellationToken = default);
}