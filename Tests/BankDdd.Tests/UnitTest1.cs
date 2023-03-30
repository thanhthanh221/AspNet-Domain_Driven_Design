using BankDdd.Domain.BankMoney;
using BankDdd.Domain.BankPhoneNumber;

namespace BankDdd.Tests;

public class UnitTest1
{
    [Fact]
    public void Should_Be_True_When_GetTheLastFourDigits()
    {
        PhoneNumber phoneNumber = new("9052662663");

        Assert.Equal("2663", phoneNumber.GetTheLastFourDigits);
    }

    [Fact]
    public void Should_Throw_Exception_When_PhoneNumberIsNotValid()
    {
        Assert.Throws<PhoneNumberIsNotValid>(() => new PhoneNumber("1467"));
    }

    [Fact]
    public void Should_Be_True_When_ComparePhoneNumber()
    {
        var phoneNumber1 = new PhoneNumber("84325826495");
        var phoneNumber2 = new PhoneNumber("84325826495");
        var phoneNumber3 = new PhoneNumber("84378630068");

        Assert.True(phoneNumber1 == phoneNumber2);
        Assert.False(phoneNumber2 == phoneNumber3);
    }

    [Fact]
    public void Should_Be_True_When_CompareCurrencies()
    {
        Money money1 = new(100M, Currency.VN);
        Money money2 = new(200M, Currency.VN);
        Money money3 = new(10, Currency.USD);
        Money money4 = new(100M, Currency.VN);

        Assert.True(money1 < money2);
        Assert.True(money2 > money1);
        Assert.True(money1 == money4);

        Assert.Throws<CurrencyIsNotValid>(() => money1 > money3);
        Assert.Throws<CurrencyIsNotValid>(() => money4 > money3);
    }
}