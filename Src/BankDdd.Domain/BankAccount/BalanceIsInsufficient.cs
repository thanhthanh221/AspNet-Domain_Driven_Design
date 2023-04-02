namespace BankDdd.Domain.BankAccount;
// Exception Thực hiện giao dịch khi không đủ tiền
public class BalanceIsInsufficient : Exception
{
    public BalanceIsInsufficient() : base("Balance is insufficient")
    {
    }
}
