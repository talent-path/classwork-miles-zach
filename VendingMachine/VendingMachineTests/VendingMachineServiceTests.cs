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

        private static readonly IVendingMachineService _service = new VendingMachineService(new InMemVendingMachineDao());

        [Test]
        public void GetAllCandies()
        {
            List<Candy> actual = _service.GetCandies();
            Assert.AreEqual(new Candy("Jolly Rancher", 1.00M, 13), actual[0]);
            Assert.AreEqual(new Candy("Almond Joy", 1.50M, 21), actual[1]);
            Assert.AreEqual(new Candy("Snickers", 2.50M, 6), actual[2]);
            Assert.AreEqual(new Candy("Three Musketeers", 3.00M, 9), actual[3]);
            Assert.AreEqual(new Candy("Starburst", 0.50M, 10), actual[4]);
            Assert.AreEqual(new Candy("Reese's Cup", 1.25M, 4), actual[5]);
            Assert.AreEqual(new Candy("Babe Ruth", 1.33M, 0), actual[6]);
            Assert.AreEqual(new Candy("Tootsie Roll", 0.27M, -1), actual[7]);
            Assert.AreEqual(8, _service.GetCandies().Count);
        }

        [TestCaseSource("TestCaseCorrectChange")]
        public void PurchaseCandyReturnsCorrectChange(Candy candy, decimal funds, Change expectedChange)
        {
            Change change = _service.PurchaseCandy(candy, funds);
            Assert.AreEqual(expectedChange.Coins[Money.Dollar], change.Coins[Money.Dollar]);
            Assert.AreEqual(expectedChange.Coins[Money.Quarter], change.Coins[Money.Quarter]);
            Assert.AreEqual(expectedChange.Coins[Money.Dime], change.Coins[Money.Dime]);
            Assert.AreEqual(expectedChange.Coins[Money.Nickel], change.Coins[Money.Nickel]);
            Assert.AreEqual(expectedChange.Coins[Money.Penny], change.Coins[Money.Penny]);
            Assert.AreEqual(expectedChange.ToDecimal(), change.ToDecimal());
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
            yield return new TestCaseData(_service.GetCandies()[0], 1.57M, new Change(0, 2, 0, 1, 2));
            yield return new TestCaseData(_service.GetCandies()[1], 10.04M, new Change(8, 2, 0, 0, 4));
            yield return new TestCaseData(_service.GetCandies()[2], 200.56M, new Change(198, 0, 0, 1, 1));
            yield return new TestCaseData(_service.GetCandies()[3], 3.99M, new Change(0, 3, 2, 0, 4));
            yield return new TestCaseData(_service.GetCandies()[4], 0.50M, new Change(0, 0, 0, 0, 0));
            yield return new TestCaseData(_service.GetCandies()[5], 1.74M, new Change(0, 1, 2, 0, 4));
        }

        private static IEnumerable<TestCaseData> OutOfStockTestCases()
        {
            yield return new TestCaseData(_service.GetCandies()[6], 2.00M);
            yield return new TestCaseData(_service.GetCandies()[7], 0.50M);
        }

    }
}