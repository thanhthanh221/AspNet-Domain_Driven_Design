namespace BankDdd.Domain.BankMoney;
public class Money
{
    public Money(decimal amount, Currency currency)
    {
        ArgumentNullException.ThrowIfNull(amount);
        ArgumentNullException.ThrowIfNull(currency);

        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }
    public Currency Currency { get; }

    public override string ToString() => $"{Amount}-{Currency}";
    public static Money Zero(Currency currency) => new(0, currency);

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())  return false;

        Money money = (Money)obj;
        return Amount == money.Amount && Currency == money.Currency;
    }

    public override int GetHashCode() => $"{Amount}+{Currency}".GetHashCode();
    public static bool operator <(Money obj1, Money obj2)
    {
        ThrowIfCurrencyIsNotMatch(obj1, obj2);
        return obj1.Amount < obj2.Amount;
    }

    public static bool operator >(Money obj1, Money obj2)
    {
        ThrowIfCurrencyIsNotMatch(obj1, obj2);
        return obj1.Amount > obj2.Amount;
    }

    public static bool operator ==(Money obj1, Money obj2)
    {
        ThrowIfCurrencyIsNotMatch(obj1, obj2);
        return obj1.Amount == obj2.Amount && obj1.Currency == obj2.Currency;
    }

    public static bool operator !=(Money obj1, Money obj2)
    {
        ThrowIfCurrencyIsNotMatch(obj1, obj2);
        return obj1.Amount != obj2.Amount || obj1.Currency != obj2.Currency;
    }

    public static Money operator +(Money obj1, Money obj2)
    {
        ThrowIfCurrencyIsNotMatch(obj1, obj2);
        return new Money(obj1.Amount + obj2.Amount, obj1.Currency);
    }

    public static Money operator -(Money obj1, Money obj2)
    {
        ThrowIfCurrencyIsNotMatch(obj1, obj2);
        return new Money(obj1.Amount - obj2.Amount, obj1.Currency);
    }

    private static void ThrowIfCurrencyIsNotMatch(Money obj1, Money obj2)
    {
        if (obj1.Currency != obj2.Currency) throw new CurrencyIsNotValid();
    }

}
