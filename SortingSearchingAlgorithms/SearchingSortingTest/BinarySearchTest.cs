using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SortingSearching;

namespace SearchingSortingTest
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void ValidSortedSearch()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 100, 101 });
            Assert.IsTrue(collection.LinearSearch(33));
        }

        [TestMethod]
        public void NegativeNumberSearch()
        {
            var collection = new SortableCollection<int>(new[] { -101, -22, 0, 11, 33, 101 });
            Assert.IsTrue(collection.LinearSearch(-101));
        }

        [TestMethod]
        public void SameNumberSearch()
        {
            var collection = new SortableCollection<int>(new[] { -101, 0, 11, 33, 33, 101 });
            Assert.IsTrue(collection.LinearSearch(33));
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
            var collection = new SortableCollection<int>(new[] { -101, -22, 0, 11, 33, 101 });
            Assert.IsFalse(collection.LinearSearch(55));
        }
    }
}
