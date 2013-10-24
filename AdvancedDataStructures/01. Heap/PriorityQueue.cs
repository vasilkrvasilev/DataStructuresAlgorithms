using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PriorityQueue<T>
{
    private readonly Heap<T> heap;

    public PriorityQueue(IComparer<T> comparer)
    {
        this.heap = new Heap<T>(new List<T>(), 0, comparer);
    }

    /// <summary>
    /// Returns number of elements in the priority queue
    /// </summary>
    public int Count 
    { 
        get { return this.heap.Count; } 
    }

    /// <summary>
    /// Select first element in the priority queue
    /// </summary>
    /// <returns>Selected element</returns>
    public T Peek() 
    { 
        return this.heap.PeekRoot(); 
    }

    /// <summary>
    /// Add element to the priority queue
    /// </summary>
    /// <param name="element">Element to add</param>
    public void Enqueue(T element) 
    { 
        this.heap.Insert(element); 
    }

    /// <summary>
    /// Delete first element of the priority queue
    /// </summary>
    /// <returns>Deleted element</returns>
    public T Dequeue() 
    { 
        return this.heap.PopRoot(); 
    }
}