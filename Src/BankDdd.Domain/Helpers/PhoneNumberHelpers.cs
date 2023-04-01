namespace BankDdd.Domain.Helpers;
public class PhoneNumberHelpers
{
    public static string GetTheLastFourDigits(string phoneNumber)
    {
        return phoneNumber[^4..];
    }
}
