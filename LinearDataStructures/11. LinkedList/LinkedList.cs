using System;

public class LinkedList<T>
{
    private ListItem<T> firstElement;

    /// <summary>
    /// First element of the list
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If try to create LinkedList with first element equal to null</exception>
    public ListItem<T> FirstElement
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

    public LinkedList(ListItem<T> firstElement)
    {
        this.FirstElement = firstElement;
    }

    /// <summary>
    /// Add element to the LinkedList
    /// </summary>
    /// <param name="element">Element to add</param>
    /// <exception cref="ArgumentNullException">
    /// If try to add element equal to null</exception>
    /// <remarks>Change first element to the added one</remarks>
    public void Add(ListItem<T> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Element of the linked list cannot be null.");
        }

        element.NextItem = this.FirstElement;
        this.FirstElement = element;
    }

    /// <summary>
    /// Remove element from the LinkedList
    /// </summary>
    /// <param name="element">Element to remove</param>
    /// <exception cref="ArgumentNullException">
    /// If try to remove element equal to null</exception>
    /// <remarks>If there is no such element in the LinkedList
    /// no one is removed</remarks>
    public void Remove(ListItem<T> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Element of the linked list cannot be null.");
        }

        ListItem<T> previousElement = null;
        ListItem<T> currentElement = this.FirstElement;
        while (!currentElement.Equals(element) || currentElement == null)
        {
            previousElement = currentElement;
            currentElement = currentElement.NextItem;
        }

        if (previousElement == null)
        {
            this.FirstElement = this.FirstElement.NextItem;
        }
        else if (currentElement == null)
        {
            return;
        }
        else
        {
            previousElement.NextItem = currentElement.NextItem;
        }
    }

    /// <summary>
    /// Find index of given element from the LinkedList
    /// </summary>
    /// <param name="element">Element, which index is searched</param>
    /// <exception cref="ArgumentNullException">
    /// Find index of element equal to null</exception>
    /// <remarks>If there is no such element in the LinkedList return -1</remarks>
    /// <returns>Index of the element</returns>
    public int IndexOf(ListItem<T> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Element of the linked list cannot be null.");
        }

        int index = 0;
        ListItem<T> currentElement = this.FirstElement;
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
    /// Find if given element is element from the LinkedList
    /// </summary>
    /// <param name="element">Element, which is searched</param>
    /// <exception cref="ArgumentNullException">
    /// Find index of element equal to null</exception>
    /// <remarks>Use IndexOf(element)</remarks>
    /// <returns>True or False</returns>
    public bool Contains(ListItem<T> element)
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
    /// Count the elements in the LinkedList
    /// </summary>
    /// <returns>The number of elements in the LinkedList</returns>
    public int Count()
    {
        int count = 0;
        ListItem<T> currentElement = this.FirstElement;
        while (currentElement != null)
        {
            currentElement = currentElement.NextItem;
            count++;
        }
        
        return count;
    }

    /// <summary>
    /// Get and Set the value of the element with given index
    /// </summary>
    /// <param name="index">The intex of the element</param>
    /// <exception cref="ArgumentException">
    /// If the index is negative number</exception>
    /// <remarks>If there is no such element in the LinkedList Get returns null
    /// and Set do not change any elements</remarks>
    /// <returns>The element with given index or null</returns>
    public ListItem<T> this[int index]
    {
        get
        {
            if (index < 0)
            {
                throw new ArgumentException(
                    "Invalid input! Index cannot be negative number.");
            }

            int count = 0;
            ListItem<T> currentElement = this.FirstElement;
            while (count < index || currentElement == null)
            {
                currentElement = currentElement.NextItem;
                count++;
            }

            return currentElement;
        }
        set
        {
            if (index < 0)
            {
                throw new ArgumentException(
                    "Invalid input! Index cannot be negative number.");
            }

            int count = 0;
            ListItem<T> previousElement = null;
            ListItem<T> currentElement = this.FirstElement;
            while (count < index || currentElement == null)
            {
                previousElement = currentElement;
                currentElement = currentElement.NextItem;
                count++;
            }

            if (currentElement == null && count == index)
            {
                previousElement.NextItem = value;
            }
            else if (currentElement != null && count == index)
            {
                previousElement.NextItem = value;
                value.NextItem = currentElement.NextItem;
            }
        }
    }
}