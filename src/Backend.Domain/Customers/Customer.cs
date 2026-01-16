namespace Backend.Domain.Customers;

public class Customer(string name, string email, string phone, string address)
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
    public string Phone { get; init; } = phone;
    public string Address { get; init; } = address;
}
