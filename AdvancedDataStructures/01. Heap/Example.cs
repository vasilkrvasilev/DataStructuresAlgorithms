using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Used to compare elements in the priority queue - sort them by chosen priority
/// </summary>
public class CompareLength : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return x.Length.CompareTo(y.Length);
    }
}

public class Example
{
    public static void Main()
    {
        PriorityQueue<string> queue = new PriorityQueue<string>(new CompareLength());
        queue.Enqueue("aasfgsd");
        queue.Enqueue("fdbgv");
        queue.Enqueue("hfvsdgnbdcdcgb");
        queue.Enqueue("a");
        Console.WriteLine(queue.Count);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
    }
}