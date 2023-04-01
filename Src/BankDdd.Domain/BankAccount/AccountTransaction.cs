using BankDdd.Domain.BankMoney;

namespace BankDdd.Domain.BankAccount;
public class AccountTransaction
{
    public AccountTransactionId Id { get; set; }
    public DateTime CreateAt { get; set; }
    public AccountTransactionType Type { get; set; }
    public Money Money { get; set; }

    public AccountTransaction(AccountTransactionId id, DateTime createAt, AccountTransactionType type, Money money)
    {
        Id = id;
        CreateAt = createAt;
        Type = type;
        Money = money;
    }
}
