using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SortingSearching;

namespace SearchingSortingTest
{
    [TestClass]
    public class QuickSorterTest
    {
        [TestMethod]
        public void QuickRandomNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new Quicksorter<int>());
            CollectionAssert.AreEqual(new[] { 0, 11, 22, 33, 101, 101 }, collection.Items.ToArray());
        }

        [TestMethod]
        public void QuickSortedNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            collection.Sort(new Quicksorter<int>());
            CollectionAssert.AreEqual(new[] { 0, 11, 22, 33, 101, 101 }, collection.Items.ToArray());
        }

        [TestMethod]
        public void QuickReversedNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            collection.Sort(new Quicksorter<int>());
            CollectionAssert.AreEqual(new[] { 0, 11, 22, 33, 101, 101 }, collection.Items.ToArray());
        }

        [TestMethod]
        public void QuickNegativeNumbers()
        {
            var collection = new SortableCollection<int>(new[] { -22, 11, 101, 33, 0, -101 });
            collection.Sort(new Quicksorter<int>());
            CollectionAssert.AreEqual(new[] { -101, -22, 0, 11, 33, 101 }, collection.Items.ToArray());
        }

        [TestMethod]
        public void QuickEqualNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 0, 0, 0, 0, 0, 0 });
            collection.Sort(new Quicksorter<int>());
            CollectionAssert.AreEqual(new[] { 0, 0, 0, 0, 0, 0 }, collection.Items.ToArray());
        }
    }
}
