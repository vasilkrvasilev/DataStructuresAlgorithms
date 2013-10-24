using System;

public class QueueItem<T>
{
    private T value;
    private QueueItem<T> nextItem;

    /// <summary>
    /// Value of the node
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If the value is equal to null</exception>
    public T Value
    {
        get { return this.value; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! First element cannot be null.");
            }

            this.value = value;
        }
    }

    /// <summary>
    /// The next item 
    /// <remarks>Initial value is equal to null.
    /// It is set when node is added or removed</remarks>
    /// </summary>
    public QueueItem<T> NextItem
    {
        get { return this.nextItem; }
        set { this.nextItem = value; }
    }

    public QueueItem(T value)
    {
        this.Value = value;
        this.NextItem = null;
    }
}