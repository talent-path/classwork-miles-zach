using System.Collections.Generic;
using NUnit.Framework;
using VendingMachineData.Data;
using VendingMachineData.Enums;
using VendingMachineData.Exceptions;
using VendingMachineData.Models;
using VendingMachineData.Services;

namespace VendingMachineTests
{
    public class VendingMachineServiceTests
    {

        private static IVendingMachineService _service = new VendingMachineService(new InMemVendingMachineDao());

        [TestCaseSource("TestCaseCorrectChange")]
        public void PurchaseCandyReturnsCorrectChange(Candy candy,
            decimal funds, decimal expectedChange, int dollars, int quarters, int dimes, int nickels, int pennies)
        {
            Change change = _service.PurchaseCandy(candy, funds);
            Assert.AreEqual(dollars, change.Coins[Money.Dollar]);
            Assert.AreEqual(quarters, change.Coins[Money.Quarter]);
            Assert.AreEqual(dimes, change.Coins[Money.Dime]);
            Assert.AreEqual(nickels, change.Coins[Money.Nickel]);
            Assert.AreEqual(pennies, change.Coins[Money.Penny]);
            Assert.AreEqual(expectedChange, change.ToDecimal());
        }

        [TestCaseSource("TestCaseInsufficientFunds")]
        public void UserCannotPurchaseCandyWithInsufficientFunds(Candy candy, decimal funds)
        {
            Assert.Throws<InsufficientFundsException>(() => _service.PurchaseCandy(candy, funds));
        }

        [TestCaseSource("OutOfStockTestCases")]
        public void QuantityEquals0ThenOutOfStockExceptionIsThrown(Candy candy, decimal funds)
        {
            Assert.Throws<OutOfStockException>(() => _service.PurchaseCandy(candy, funds));
        }

        private static IEnumerable<TestCaseData> TestCaseInsufficientFunds()
        {
            yield return new TestCaseData(_service.GetCandies()[0], 0.99M);
            yield return new TestCaseData(_service.GetCandies()[1], 1.49M);
            yield return new TestCaseData(_service.GetCandies()[2], 2.49M);
            yield return new TestCaseData(_service.GetCandies()[3], 2.99M);
            yield return new TestCaseData(_service.GetCandies()[4], 0.49M);
            yield return new TestCaseData(_service.GetCandies()[5], 1.24M);
        }

        private static IEnumerable<TestCaseData> TestCaseCorrectChange()
        {
            yield return new TestCaseData(_service.GetCandies()[0], 1.57M, 0.57M, 0, 2, 0, 1, 2);
            yield return new TestCaseData(_service.GetCandies()[1], 10.04M, 8.54M, 8, 2, 0, 0, 4);
            yield return new TestCaseData(_service.GetCandies()[2], 200.56M, 198.06M, 198, 0, 0, 1, 1);
            yield return new TestCaseData(_service.GetCandies()[3], 3.99M, 0.99M, 0, 3, 2, 0, 4);
            yield return new TestCaseData(_service.GetCandies()[4], 0.50M, 0.0M, 0, 0, 0, 0, 0);
            yield return new TestCaseData(_service.GetCandies()[5], 1.74M, 0.49M, 0, 1, 2, 0, 4);
        }

        private static IEnumerable<TestCaseData> OutOfStockTestCases()
        {
            yield return new TestCaseData(_service.GetCandies()[6], 2.00M);
            yield return new TestCaseData(_service.GetCandies()[7], 0.50M);
        }

    }
}