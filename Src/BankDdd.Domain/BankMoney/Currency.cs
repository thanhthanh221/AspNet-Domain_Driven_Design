namespace BankDdd.Domain.BankMoney;
public record Currency
{
    public static Currency VN = new("VND", "đ");
    public static Currency USD = new("USD","$");

    public Currency(string name, string bymbol)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(bymbol);

        Name = name;
        Bymbol = bymbol;
    }

    public string Name { get; }
    public string Bymbol { get; }

    public override string ToString() => Bymbol;
    public static implicit operator string(Currency currency) => currency.ToString();
}
