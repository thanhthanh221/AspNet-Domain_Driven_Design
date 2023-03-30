namespace BankDdd.Domain.BankMoney;
public class CurrencyIsNotValid : Exception
{
    public CurrencyIsNotValid() : base("the currency is not valid")
    {
    }
}
