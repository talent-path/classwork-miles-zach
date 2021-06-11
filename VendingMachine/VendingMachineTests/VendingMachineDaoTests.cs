using System;
using NUnit.Framework;
using VendingMachineData.Data;
using VendingMachineData.Models;

namespace VendingMachineTests
{
    public class VendingMachineDaoTests
    {

        private IVendingMachineDao _dao;

        [OneTimeSetUp]
        public void SetupOnce()
        {
            _dao = new VendingMachineDao();
        }

        [TestCase("Jolly Rancher", 0, 12)]
        [TestCase("Almond Joy", 1, 20)]
        [TestCase("Snickers", 2, 5)]
        [TestCase("Three Musketeers", 3, 8)]
        [TestCase("Starburst", 4, 9)]
        [TestCase("Reese's Cup", 5, 3)]
        [TestCase("Jolly Rancher", 0, 11)]
        [TestCase("Almond Joy", 1, 19)]
        [TestCase("Snickers", 2, 4)]
        [TestCase("Three Musketeers", 3, 7)]
        [TestCase("Starburst", 4, 8)]
        [TestCase("Reese's Cup", 5, 2)]
        [TestCase("Reese's Cup", 5, 1)]
        [TestCase("Reese's Cup", 5, 0)]
        public void RemoveCandyUpdatesVendingMachine(string candyName, int index, int expectedQty)
        {
            _dao.RemoveCandy(candyName);
            Assert.AreEqual(expectedQty, _dao.GetVendingMachine().Candies[index].Qty);
        }
    }
}
