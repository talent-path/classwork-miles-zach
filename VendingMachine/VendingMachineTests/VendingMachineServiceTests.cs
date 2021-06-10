using System.Collections.Generic;
using NUnit.Framework;
using VendingMachineData.Data;
using VendingMachineData.Enums;
using VendingMachineData.Models;
using VendingMachineData.Services;

namespace VendingMachineTests
{
    public class VendingMachineServiceTests
    {

        private IVendingMachineService _service;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            _service = new VendingMachineService(new VendingMachineDao());
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void UserPurchaseReturnsCorrectChange()
        {
            List<Candy> candies = _service.GetCandies();
            decimal funds = 2.00M;
            Change change = _service.PurchaseCandy(candies[0], funds);
            Assert.That(change.Coins.ContainsKey(Money.Dollar));
            Assert.AreEqual(1, change.Coins.GetValueOrDefault(Money.Dollar));
        }

        [Test]
        public void PurchaseCandyWithOddNumberOfChangeLeft()
        {
            Assert.Fail();
        }

        [Test]
        public void UserCannotPurchaseCandyWithInsufficientFunds()
        {
            Assert.Fail();
        }
        
    }
}