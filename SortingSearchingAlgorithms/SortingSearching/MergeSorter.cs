namespace SortingSearching
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            List<T> exchange = new List<T>();
            T[] array = new T[collection.Count];
            exchange.AddRange(array);

            // Start MergeSort of collection (exchange is used to change the place of the elements)
            MergeSort(collection, exchange, 0, collection.Count - 1);
        }

        static void MergeSort(IList<T> collection, IList<T> exchange, int leftIndex, int rightIndex)
        {
            // Bottom of the recursion
            if (leftIndex >= rightIndex)
            {
                return;
            }

            // Split current section to two parts, start MergeSort for them and merge them after that
            int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
            MergeSort(collection, exchange, leftIndex, middleIndex);
            MergeSort(collection, exchange, middleIndex + 1, rightIndex);
            Merge(collection, exchange, leftIndex, middleIndex, rightIndex);
        }

        static void Merge(IList<T> collection, IList<T> exchange, int leftIndex, int middleIndex, int rightIndex)
        {
            int leftHalfIndex = leftIndex;
            int rightHalfIndex = middleIndex + 1;
            int exchangeIndex = leftIndex;

            // Compare elements of sorted parts
            while (leftHalfIndex <= middleIndex && rightHalfIndex <= rightIndex)
            {
                if (collection[leftHalfIndex].CompareTo(collection[rightHalfIndex]) < 0)
                {
                    exchange[exchangeIndex] = collection[leftHalfIndex];
                    leftHalfIndex++;
                }
                else
                {
                    exchange[exchangeIndex] = collection[rightHalfIndex];
                    rightHalfIndex++;
                }

                exchangeIndex++;
            }

            // Copy left not merged elements from first part if there are such
            while (leftHalfIndex <= middleIndex)
            {
                exchange[exchangeIndex] = collection[leftHalfIndex];
                exchangeIndex++;
                leftHalfIndex++;
            }

            // Copy left not merged elements from second part if there are such
            while (rightHalfIndex <= rightIndex)
            {
                exchange[exchangeIndex] = collection[rightHalfIndex];
                exchangeIndex++;
                rightHalfIndex++;
            }

            // Save changes to the original array (collection)
            for (int index = leftIndex; index <= rightIndex; index++)
            {
                collection[index] = exchange[index];
            }
        }
    }
}