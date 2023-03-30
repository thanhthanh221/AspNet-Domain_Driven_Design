using System.Text.RegularExpressions;

namespace BankDdd.Domain.BankPhoneNumber;

public record PhoneNumber
{
    public PhoneNumber(string value)
    {
        if (!Regex.IsMatch(value, "^\\+?[1-9][0-9]{7,14}$"))
        {
            throw new PhoneNumberIsNotValid();
        }
        Value = value;
    }
    public string Value { get; }

    public string GetTheLastFourDigits => Value[^4..];
}
