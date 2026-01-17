namespace Backend.Domain.Customers;

public class Customer
{
    public Customer(string name, string email, string phone, string address)
    {
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
        this.Address = address;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Address { get; init; }
}
