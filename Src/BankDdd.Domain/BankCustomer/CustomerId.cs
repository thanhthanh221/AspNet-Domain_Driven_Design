namespace BankDdd.Domain.BankCustomer;
public class CustomerId
{
    public CustomerId(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Id = id;
    }

    public Guid Id {get; set;}

}
