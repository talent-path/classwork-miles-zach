using NUnit.Framework;
using VendingMachineData.Data;
using System.IO;
using System.Collections.Generic;
using VendingMachineData.Models;
using System.Linq;

namespace VendingMachineTests
{
    public class VendingMachineDaoTests
    {

        private IVendingMachineDao _dao;

        private static string testPath = "../../../../VendingMachine/Test.txt";

        private static string seedPath = "../../../../VendingMachine/Seed.txt";

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
        [TestCase("Biden")]
        [TestCase("Trump")]
        [TestCase("Pizza")]
        [TestCase("Fake News Media")]
        [TestCase("Make America Great Again")]
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
