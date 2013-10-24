namespace SortingSearching
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private static IList<T> QuickSort<T>(IList<T> collection, int down, int up) 
            where T : IComparable<T>
        {
            int downLimit = down;
            int upperLimit = up;
            T pivot = collection[(down + up) / 2];

            while (downLimit <= upperLimit)
            {
                while (collection[downLimit].CompareTo(pivot) < 0)
                {
                    downLimit++;
                }

                while (collection[upperLimit].CompareTo(pivot) > 0)
                {
                    upperLimit--;
                }

                if (downLimit <= upperLimit)
                {
                    T exchangeValue = collection[downLimit];
                    collection[downLimit] = collection[upperLimit];
                    collection[upperLimit] = exchangeValue;
                    downLimit++;
                    upperLimit--;
                }
            }

            if (down < upperLimit)
            {
                QuickSort(collection, down, upperLimit);
            }

            if (downLimit < up)
            {
                QuickSort(collection, downLimit, up);
            }

            return collection;
        }
    }
}