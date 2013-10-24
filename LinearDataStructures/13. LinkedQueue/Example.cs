using System;

public class Example
{
    public static void Main()
    {
        // Create LinkedQueue and test its methods
        QueueItem<string> element = new QueueItem<string>("a");
        LinkedQueue<string> queue = new LinkedQueue<string>(element);
        queue.Enqueue(new QueueItem<string>("b"));
        queue.Enqueue(new QueueItem<string>("c"));
        queue.Enqueue(new QueueItem<string>("d"));
        queue.Enqueue(new QueueItem<string>("e"));
        QueueItem<string> firstElement = queue.Dequeue();
        QueueItem<string> newFirstElement = queue.Peek();
        int count = queue.Count();
        bool hasElement = queue.Contains(new QueueItem<string>("z"));
    }
}