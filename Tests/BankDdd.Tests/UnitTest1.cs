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

    [Fact]
    public void Should_Be_True_When_CompareCustomers()
    {
        Customer customer1 = new(new CustomerId(Guid.NewGuid()), "Bui", "Quang");
        Customer customer2 = new(customer1.Id, "Ta", "Yen");
        Customer customer3 = new(new CustomerId(Guid.NewGuid()), "Ta", "Phuong")
        {
            PhoneNumber = new PhoneNumber("84325626311")
        };
        customer3.UpdateName("Minh", "Phuong");

        Assert.True(customer1.Equals(customer2));
        Assert.False(customer1.Equals(customer3));
    }

    [Fact]
    public void Should_Succeed_When_WithDrawMoney()
    {
        Customer customer = new(new CustomerId(Guid.NewGuid()), "Bui", "Quang");
        Account account = new(new AccountId(Guid.NewGuid()), customer.Id, Currency.VN);
        AccountManager accountManager = new();

        account.Deposit(new Money(600M, Currency.VN));
        accountManager.WithDraw(account, customer, new Money(100M, Currency.VN));

        Assert.Equal(new Money(500M, Currency.VN), account.Balance);

        var deposit = account.Transactions.FirstOrDefault();
        var withdraw = account.Transactions.ElementAt(1);

        Assert.Equal(deposit.Money, new Money(600M, Currency.VN));
        Assert.Equal(withdraw.Money, new Money(100M, Currency.VN));
    }

    [Fact]
    public void Should_Throw_Exception_BalanceIsInsufficient_When_AmountIssGreateThanBlance()
    {
        Customer customer = new(new CustomerId(Guid.NewGuid()), "Bui", "Quang");
        Account account = new(new AccountId(Guid.NewGuid()), customer.Id, Currency.VN);
        AccountManager accountManager = new();

        account.Deposit(new Money(600M, Currency.VN));
        accountManager.WithDraw(account, customer, new Money(100M, Currency.VN));

        Assert.Throws<BalanceIsInsufficient>(() => accountManager.WithDraw(account, customer, new Money(600M, Currency.VN)));

        Assert.Equal(new Money(500M, Currency.VN), account.Balance);
    }

    [Fact]
    public void Should_Throw_Exception_CustomerIsBlocked_When_CustomerIsBlocked_ImpureDomainInModel()
    {
        Customer customer = new(new CustomerId(Guid.NewGuid()), "Bui", "Quang");
        customer.Block("Test");

        var account = new Account(new AccountId(Guid.NewGuid()), customer.Id, Currency.VN);
        account.Deposit(new Money(600M, Currency.VN));

        Mock<ICustomerRepository> mockCustomerRepository = new();
        mockCustomerRepository.Setup(r => r.GetCustomer(It.IsAny<CustomerId>())).Returns(customer);

        Assert.Throws<CustomerIsBlocked>(() => account.WithDraw(new Money(600M, Currency.VN), mockCustomerRepository.Object));
        Assert.Equal(new Money(600M, Currency.VN), account.Balance);
    }

    [Fact]
    public void Should_Throw_Exception_CustomerIsBlocked_When_CustomerIsBlocked_PureDomainInModel()
    {
        Customer customer = new(new CustomerId(Guid.NewGuid()), "Bui", "Quang");
        customer.Block("Test");

        Account account = new(new AccountId(Guid.NewGuid()), customer.Id, Currency.VN);
        account.Deposit(new Money(600M, Currency.VN));

        AccountManager accountManager = new();

        Assert.Throws<CustomerIsBlocked>(() => accountManager.WithDraw(account, customer, new Money(600M, Currency.VN)));
        Assert.Equal(new Money(600M, Currency.VN), account.Balance);
    }
}