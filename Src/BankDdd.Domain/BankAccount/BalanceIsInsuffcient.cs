namespace BankDdd.Domain.BankAccount;
// Exception Thực hiện giao dịch khi không đủ tiền
public class BalanceIsInsuffcient : Exception
{
    public BalanceIsInsuffcient() : base("Balance is insufficient")
    {
    }
}
