using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SortingSearching;

namespace SearchingSortingTest
{
    [TestClass]
    public class LinearSearchTest
    {
        [TestMethod]
        public void ValidSearch()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Assert.IsTrue(collection.LinearSearch(101));
        }

        [TestMethod]
        public void ValidSortedSearch()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 100, 101 });
            Assert.IsTrue(collection.LinearSearch(101));
        }

        [TestMethod]
        public void NegativeNumberSearch()
        {
            var collection = new SortableCollection<int>(new[] { -22, 11, 101, 33, 0, -101 });
            Assert.IsTrue(collection.LinearSearch(-101));
        }

        [TestMethod]
        public void EqualNumberSearch()
        {
            var collection = new SortableCollection<int>(new[] { 0, 0, 0, 0, 0, 0 });
            Assert.IsTrue(collection.LinearSearch(0));
        }

        [TestMethod]
        public void InvalidSearch()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, -101 });
            Assert.IsFalse(collection.LinearSearch(55));
        }
    }
}
