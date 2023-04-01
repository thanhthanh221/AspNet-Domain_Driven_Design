using BankDdd.Domain.BankPhoneNumber;

namespace BankDdd.Domain.BankCustomer;
public class Customer
{
    public CustomerId Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Customer(CustomerId id, string firstName, string lastName)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(lastName);

        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public void UpdateName(string firstName, string lastName)
    {
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(lastName);

        FirstName = firstName;
        LastName = lastName;
    }

    public override bool Equals(object obj) => obj is Customer customer && customer.Id == Id;
    public override int GetHashCode() => Id.GetHashCode();
}
