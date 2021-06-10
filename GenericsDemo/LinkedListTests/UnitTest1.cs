using NUnit.Framework;
using LinkedList;
using System.Linq;
using System;

namespace LinkedListTests
{
    
    public class Tests
    {

        private DavidLinkedList<string> _list = new DavidLinkedList<string>();

        [SetUp]
        public void Setup()
        {
            _list = new DavidLinkedList<string> { "one", "two", "three" };
        }

        [Test]
        public void LinkedListAdd(
            [Values("four", "")] string fourth,
            [Values("five", "")] string fifth)
        {
            _list.Add(fourth);
            _list.Add(fifth);
            Assert.AreEqual(fourth, _list.Skip(3).First());
            Assert.AreEqual(fifth, _list.Skip(4).First());
        }

        [TestCase("one", "two")]
        public void LinkedListRemove(string first, string second)
        {
            _list.Remove(first);
            _list.Remove(second);
            
        }

        [Test]
        public void LinkedListRemoveNotFound()
        {
            Assert.Throws<ItemNotFoundException>(() => _list.Remove("four"));
        }

        [Test]
        public void LinkedListAddNullTest()
        {
            Assert.Throws<ArgumentNullException>(() =>_list.Add(null));
        }
    }
}