namespace BankDdd.Domain.BankAccount;
public class AccountId
{
    public Guid Id { get; set; }
    public AccountId(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Id = id;
    }

}
