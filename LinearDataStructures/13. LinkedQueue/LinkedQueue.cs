using System;

public class LinkedQueue<T>
{
    private QueueItem<T> firstElement;
    private QueueItem<T> lastElement;

    /// <summary>
    /// First element of the list
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If try to create LinkedQueue with first element equal to null</exception>
    public QueueItem<T> FirstElement
    {
        get { return this.firstElement; }
        set 
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! First element cannot be null.");
            }

            this.firstElement = value; 
        }
    }

    public LinkedQueue(QueueItem<T> firstElement)
    {
        this.FirstElement = firstElement;
        this.lastElement = firstElement;
    }

    /// <summary>
    /// Add element to the LinkedQueue
    /// </summary>
    /// <param name="element">Element to add</param>
    /// <exception cref="ArgumentNullException">
    /// If try to add element equal to null</exception>
    /// <remarks>Change last element to the added one</remarks>
    public void Enqueue(QueueItem<T> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Element of the linked queue cannot be null.");
        }

        this.lastElement.NextItem = element;
        this.lastElement = element;
    }

    /// <summary>
    /// Remove first element of the LinkedQueue
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// If try to remove element from LinkedQueue with one element</exception>
    /// <remarks>Change first element to its next element</remarks>
    public QueueItem<T> Dequeue()
    {
        if (this.FirstElement == this.lastElement)
        {
            throw new InvalidOperationException(
                "Invalid operation! Cannot remove (dequeue) first element.");
        }

        QueueItem<T> element = this.FirstElement;
        this.FirstElement = this.FirstElement.NextItem;
        return element;
    }

    /// <summary>
    /// Return the first element of the LinkedQueue
    /// </summary>
    /// <returns>First element of the LinkedQueue</returns>
    public QueueItem<T> Peek()
    {
        return this.FirstElement;
    }

    /// <summary>
    /// Find index of given element from the LinkedQueue
    /// </summary>
    /// <param name="element">Element, which index is searched</param>
    /// <exception cref="ArgumentNullException">
    /// Find index of element equal to null</exception>
    /// <remarks>If there is no such element in the LinkedQueue return -1</remarks>
    /// <returns>Index of the element</returns>
    public int IndexOf(QueueItem<T> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Element of the linked queue cannot be null.");
        }

        int index = 0;
        QueueItem<T> currentElement = this.FirstElement;
        while (!currentElement.Equals(element) || currentElement == null)
        {
            currentElement = currentElement.NextItem;
            index++;
        }

        if (currentElement == null)
        {
            return -1;
        }
        else
        {
            return index;
        }
    }

    /// <summary>
    /// Find if given element is element from the LinkedQueue
    /// </summary>
    /// <param name="element">Element, which is searched</param>
    /// <exception cref="ArgumentNullException">
    /// Find index of element equal to null</exception>
    /// <remarks>Use IndexOf(element)</remarks>
    /// <returns>True or False</returns>
    public bool Contains(QueueItem<T> element)
    {
        bool hasElement = true;
        int index = this.IndexOf(element);
        if (index == -1)
        {
            hasElement = false;
        }

        return hasElement;
    }

    /// <summary>
    /// Count the elements in the LinkedQueue
    /// </summary>
    /// <returns>The number of elements in the LinkedQueue</returns>
    public int Count()
    {
        int count = 0;
        QueueItem<T> currentElement = this.FirstElement;
        while (currentElement == null)
        {
            currentElement = currentElement.NextItem;
            count++;
        }
        
        return count;
    }
}