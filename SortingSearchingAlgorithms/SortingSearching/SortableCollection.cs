namespace SortingSearching
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool found = false;
            for (int index = 0; index < this.items.Count; index++)
            {
                if (this.items[index].Equals(item))
                {
                    found = true;
                }
            }

            return found;
        }

        public bool BinarySearch(T item)
        {
            int elements = this.items.Count;
            bool found = false;
            int firstElement = 0;
            int endElement = elements - 1;
            int middleElement = elements / 2;

            while (elements > 0)
            {
                // Check is the current element searched one
                if (item.CompareTo(this.items[middleElement]) == 0)
                {
                    found = true;
                    break;
                }
                else if (item.CompareTo(this.items[middleElement]) < 0)
                {
                    // If current element is bigger than searched one search in left half
                    if (firstElement != middleElement)
                    {
                        endElement = middleElement - 1;
                        elements = middleElement - firstElement;
                        middleElement = firstElement + elements / 2;
                    }
                    else
                    {
                        elements = 0;
                    }
                }
                else
                {
                    // If current element is smaller than searched one search in right half
                    if (firstElement != middleElement)
                    {
                        firstElement = middleElement + 1;
                        elements = endElement - middleElement;
                        middleElement = firstElement + elements / 2;
                    }
                    else
                    {
                        elements = 0;
                    }
                }
            }

            return found;
        }

        public void Shuffle()
        {
            var elements = this.items.Count;
            for (int index = 0; index < elements; index++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                int randomIndex = index + RandomProvider.Instance.Next(0, elements - index);
                var exchange = this.items[index];
                this.items[index] = this.items[randomIndex];
                this.items[randomIndex] = exchange;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}