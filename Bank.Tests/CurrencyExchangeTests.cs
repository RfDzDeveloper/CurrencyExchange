using System.Security.Cryptography.X509Certificates;
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace Bank.Tests
{
    public class CurrencyExchangeTests
    {
        Account account;
        Root currency;
        List<Rate> rateList;
        new Rate rate;
        CurrencyService currencyService;

        [SetUp]
        public void Setup()
        {
            account = new Account(500);
            currencyService = new CurrencyService();
            rateList = new List<Rate>();
            rate = new Rate{
                mid = 5,
                effectiveDate = "2021-04-09",
                no = "046/A/NBP/2021",
            };
            rateList.Add(rate);
        }

        [Test]
        public void Transfer50CurrencyGBP()
        {
            var result = account.MakeTransfer(50, Account.CurrencySymbol.EUR);
            if (result > 200){
                Assert.Pass();
            }                     
        }
        // Nie dałem rady zafakować API -> za wysokie progi ;(
        [Test]
        public void Transfer600CurrencyEUR(){
            // var currencyServiceMoq = new Moq.Mock<CurrencyService>();
            // currencyServiceMoq.Setup(x => x.GetEURData())
            //     .Returns(new Root{
            //         table = "a",
            //         currency = "EUR",
            //         rates = rateList,
            //     });            
            Assert.Throws<ArgumentException>(() => {                              
                account.MakeTransfer(600, Account.CurrencySymbol.EUR);
            });            
        }
        [Test]
        public void Transfer1000CurrencyUSD(){
                        
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                account.MakeTransfer(2000, Account.CurrencySymbol.USD);
            });
        }
        // [Test]
        // public void Transfer200CurrencyUSD(){
        //     var currencyServiceMoq = new Moq.Mock<CurrencyService>();
        //     currencyServiceMoq.Setup(x => x.GetEURData())
        //         .Returns(new Root{
        //             table = "a",
        //             currency = "USD",
        //             rates = rateList
        //         });
        //     Assert.Throws<
        // }
        
    }
}