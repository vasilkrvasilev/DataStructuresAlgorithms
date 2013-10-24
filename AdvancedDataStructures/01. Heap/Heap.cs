using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Heap<T>
{
    private readonly IList<T> list;
    private readonly IComparer<T> comparer;

    public int Count { get; private set; }

    public Heap(IList<T> list, int count, IComparer<T> comparer)
    {
        this.comparer = comparer;
        this.list = list;
        this.Count = count;
        this.Heapify();
    }

    private void Heapify()
    {
        int startIndex = this.Parent(this.Count - 1);
        for (int index = startIndex; index >= 0; index--)
        {
            this.HeapDown(index);
        }
    }

    private int Parent(int index) 
    {
        if (index <= 0)
        {
            return -1;
        }
        else
        {
            return this.SafeIndex((index - 1) / 2); 
        }
    }

    private int SafeIndex(int index) 
    {
        if (index < this.Count)
        {
            return index;
        }
        else
        {
            return -1;
        } 
    }

    private void HeapDown(int index)
    {
        while (true)
        {
            int leftIndex = this.SafeIndex(2 * index + 1);
            if (leftIndex < 0)
            {
                break;
            }

            int rightIndex = this.SafeIndex(2 * index + 2);

            int childIndex = 0;
            if (rightIndex < 0)
            {
                childIndex = leftIndex;
            }
            else
            {
                if (comparer.Compare(list[leftIndex], list[rightIndex]) > 0)
                {
                    childIndex = leftIndex;
                }
                else
                {
                    childIndex = rightIndex;
                }
            }

            if (comparer.Compare(list[childIndex], list[index]) < 0)
            {
                break;
            }

            this.SwapCells(index, childIndex);
            index = childIndex;
        }
    }

    private void SwapCells(int first, int second)
    {
        T exchange = this.list[first];
        this.list[first] = this.list[second];
        this.list[second] = exchange;
    }

    private void HeapUp(int index)
    {
        T element = this.list[index];
        while (true)
        {
            int parentIndex = this.Parent(index);
            if (parentIndex < 0 || comparer.Compare(list[parentIndex], element) > 0)
            {
                break;
            }

            this.SwapCells(index, parentIndex);
            index = parentIndex;
        }
    }

    /// <summary>
    /// Delete first element in the heap
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// If the heap is empty</exception>
    /// <returns>Deleted element</returns>
    public T PopRoot()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException(
                "Invalid operation! The heap is empty.");
        }

        var root = this.list[0];
        this.SwapCells(0, this.Count - 1);
        this.Count--;
        this.HeapDown(0);
        return root;
    }

    /// <summary>
    /// Select first element in the heap
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// If the heap is empty</exception>
    /// <returns>Selected (first) element</returns>
    public T PeekRoot()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException(
                "Invalid operation! The heap is empty.");
        }

        return this.list[0];
    }

    /// <summary>
    /// Insert element to the heap
    /// </summary>
    /// <param name="element">Element to insert</param>
    public void Insert(T element)
    {
        if (this.Count >= this.list.Count)
        {
            this.list.Add(element);
        }
        else
        {
            this.list[this.Count] = element;
        }

        this.Count++;
        this.HeapUp(this.Count - 1);
    }   
}