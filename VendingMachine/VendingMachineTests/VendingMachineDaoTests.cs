using NUnit.Framework;
using VendingMachineData.Data;
using System.IO;
using System.Collections.Generic;
using VendingMachineData.Models;

namespace VendingMachineTests
{
    public class VendingMachineDaoTests
    {

        private IVendingMachineDao _dao;

        private static readonly string testPath = "../../../../VendingMachine/Test.txt";

        private static readonly string seedPath = "../../../../VendingMachine/Seed.txt";

        [OneTimeSetUp]
        public void SetupOnce()
        {
            _dao = new FileVendingMachineDao(testPath);
        }

        [SetUp]
        public void Setup()
        {
            File.Delete(testPath);
            File.Copy(seedPath, testPath);
        }

        [Test]
        public void GetAllCandies()
        {
            List<Candy> actual = _dao.GetCandies();
            Assert.AreEqual(new Candy("Jolly Rancher", 1.00M, 13), actual[0]);
            Assert.AreEqual(new Candy("Almond Joy", 1.50M, 21), actual[1]);
            Assert.AreEqual(new Candy("Snickers", 2.50M, 6), actual[2]);
            Assert.AreEqual(new Candy("Three Musketeers", 3.00M, 9), actual[3]);
            Assert.AreEqual(new Candy("Starburst", 0.50M, 10), actual[4]);
            Assert.AreEqual(new Candy("Reese's Cup", 1.25M, 4), actual[5]);
            Assert.AreEqual(6, _dao.GetCandies().Count);
        }

        [TestCase("Jolly Rancher", 0, 12)]
        [TestCase("Almond Joy", 1, 20)]
        [TestCase("Snickers", 2, 5)]
        [TestCase("Three Musketeers", 3, 8)]
        [TestCase("Starburst", 4, 9)]
        [TestCase("Reese's Cup", 5, 3)]
        public void RemoveCandyUpdatesVendingMachine(string candyName, int index, int expectedQty)
        {
            _dao.RemoveCandy(candyName);
            Assert.AreEqual(expectedQty, _dao.GetCandies()[index].Qty);
        }

        [TestCase("Aliens")]
        [TestCase(",.*@")]
        [TestCase("")]
        [TestCase(null)]
        public void RemoveCandyWithNonExistentNameShouldNotAlterList(string name)
        {
            List<Candy> before = _dao.GetCandies();
            _dao.RemoveCandy(name);
            List<Candy> after = _dao.GetCandies();
            Assert.AreEqual(before.Count, after.Count);
            Assert.That(before, Is.EquivalentTo(after));
        }
        
    }
}
