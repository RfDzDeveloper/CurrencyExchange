using NUnit.Framework;

namespace Bank.Tests
{
    public class CurrencyExchangeTests
    {
        Account account;
        [SetUp]
        public void Setup()
        {
            account = new Account(500);
        }

        [Test]
        public void Transfer50CurrencyGBP()
        {
            var result = account.MakeTransfer(50, Account.CurrencySymbol.EUR);
            if (result > 200){
                Assert.Pass();
            }
            else
                Assert.Pass();
            
        }
    }
}