namespace SortingSearching
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            T minNumber = collection[0];
            int currentPosition = 0;
            for (int iteration = 1; iteration < collection.Count; iteration++)
            {
                for (int position = iteration - 1; position < collection.Count; position++)
                {
                    if (collection[position].CompareTo(minNumber) < 0)
                    {
                        minNumber = collection[position];
                        currentPosition = position;
                    }
                }

                T exchangeNumber = collection[iteration - 1];
                collection[iteration - 1] = collection[currentPosition];
                collection[currentPosition] = exchangeNumber;
                minNumber = collection[iteration];
                currentPosition = iteration;
            }
        }
    }
}