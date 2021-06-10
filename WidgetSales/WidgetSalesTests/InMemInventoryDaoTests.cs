using System;
using System.Collections.Generic;
using NUnit.Framework;
using WidgetSales;

namespace WidgetSalesTests
{
    public class InMemInventoryDaoTests
    {
        InMemInventoryDao _toTest;

        [OneTimeSetUp]
        public void Setup()
        {
            _toTest = new InMemInventoryDao();

            WidgetInventory first = new WidgetInventory
            {
                Category = "firstCat",
                Name = "test1",
                StockCount = 1
            };
            WidgetInventory second = new WidgetInventory
            {
                Category = "firstCat",
                Name = "test2",
                StockCount = 1
            };
            WidgetInventory third = new WidgetInventory
            {
                Category = "secondCat",
                Name = "test3",
                StockCount = 1
            };
            WidgetInventory fourth = new WidgetInventory
            {
                Category = "secondCat",
                Name = "test4",
                StockCount = 1
            };
            WidgetInventory fifth = new WidgetInventory
            {
                Category = "thirdCat",
                Name = "test5",
                StockCount = 1
            };

            _toTest.Add(first);
            _toTest.Add(second);
            _toTest.Add(third);
            _toTest.Add(fourth);
            _toTest.Add(fifth);

        }

        [TestCase( "lumber", 1, "building supplies")]
        public void TestAddWidgetInventory(string name, int qty, string cat )
        {
            WidgetInventory toAdd = new WidgetInventory {
                Category = cat,
                Name = name,
                StockCount = qty };
            int addedId = _toTest.Add(toAdd);

            WidgetInventory savedWidget = _toTest.GetByName(name);


            Assert.AreEqual(savedWidget.Id, addedId);
            Assert.AreEqual(savedWidget.Name, name);
            Assert.AreEqual(savedWidget.Category, cat);
            Assert.AreEqual(savedWidget.StockCount, qty);
        }

        [Test]
        public void ShouldNotBeAbleToChangeAddedWidget()
        {
            WidgetInventory toAdd = new WidgetInventory
            {
                Category = "test",
                Name = "test",
                StockCount = 1
            };

            _toTest.Add(toAdd);

            toAdd.Name = "x";

            var storedWidget = _toTest.GetByName("test");
            Assert.AreEqual("test", storedWidget.Name);
        }

        [TestCase("test1", 1, null)]
        [TestCase("test2", -1, "secondTest")]
        [TestCase(null, 1, "thirdTest")]
        public void ShouldNotBeAbleToAddNullWidgetWithNullProperty(string name, int qty, string category)
        {
            WidgetInventory nullAdd = new WidgetInventory
            {
                Category = category,
                Name = name,
                StockCount = qty
            };

            Assert.Throws<Exception>(() => _toTest.Add(nullAdd));
        }

        [TestCase("test1")]
        [TestCase("test2")]
        [TestCase("test3")]
        public void GetWidgetByName(string name)
        {
            WidgetInventory GetFirstTest = _toTest.GetByName(name);

            Assert.AreEqual(name, GetFirstTest.Name);
        }

        [TestCase("test100")]
        public void ShouldNotBeAbleToGetWidgetNameThatDoesNotExist(string name)
        {
            Assert.Throws<Exception>(() => _toTest.GetByName(name));
        }

        [TestCase("test1")]
        [TestCase("test2")]
        public void TestRemoveWidgetByName(string name)
        {
            WidgetInventory tempW = _toTest.GetByName(name);

            Assert.AreEqual(name, tempW.Name);

            _toTest.RemoveWidgetByName(name);

            Assert.Throws<Exception>(() => _toTest.GetByName(name));
        }

        [TestCase("test100")]
        public void ShouldNotBeAbleToRemoveWidgetWithNameThatDoesNotExist(string name)
        {
            int countBeforeRemove = _toTest.GetWidgetInventoryCount();

            _toTest.RemoveWidgetByName(name);

            int countAfterRemove = _toTest.GetWidgetInventoryCount();

            Assert.AreEqual(countBeforeRemove, countAfterRemove);
        }

        [TestCase("newName", 1, "newCategory", 3)]
        [TestCase("newName2", 1, "newCategory2", 5)]
        public void TestEditWidgetById(string name, int qty, string cat, int Id)
        {
            _toTest.EditWidget(new WidgetInventory()
            {
                Category = cat,
                Id = Id,
                StockCount = qty,
                Name = name
            }); ;

            WidgetInventory toAssert = _toTest.GetByName(name);
            Assert.AreEqual(Id, toAssert.Id);
            Assert.AreEqual(cat, toAssert.Category);
            Assert.AreEqual(name, toAssert.Name);
            Assert.AreEqual(qty, toAssert.StockCount);
        }
    }
}