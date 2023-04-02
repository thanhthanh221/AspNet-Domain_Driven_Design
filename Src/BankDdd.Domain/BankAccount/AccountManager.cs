using BankDdd.Domain.BankCustomer;
using BankDdd.Domain.BankMoney;

namespace BankDdd.Domain.BankAccount;
public class AccountManager
{
    public void WithDraw(Account account, Customer customer, Money money) {
        if(customer.IsBlocked) throw new CustomerIsBlocked();

        account.WithDraw(money);
    }
}
