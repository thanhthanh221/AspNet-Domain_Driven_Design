namespace BankDdd.Domain.BankPhoneNumber;
public class PhoneNumberIsNotValid : Exception
{
    public PhoneNumberIsNotValid() : base("Phone Number is not valid")
    {
    }
}
