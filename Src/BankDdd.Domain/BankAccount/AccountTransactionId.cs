namespace BankDdd.Domain.BankAccount;
public class AccountTransactionId
{
    public Guid Id { get; set; }
    public AccountTransactionId(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Id = id;
    }

}
