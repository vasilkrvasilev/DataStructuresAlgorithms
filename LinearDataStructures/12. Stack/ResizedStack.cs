using System;

public class ResizedStack<T>
{
    private const int INITIAL_CAPACITY = 4;
    private T[] elements;
    private int count = 0;

    /// <summary>
    /// Return the number of elements in the ResizedStack
    /// </summary>
    public int Count 
    { 
        get { return this.count; } 
    }

    public ResizedStack()
    {
        this.elements = new T[INITIAL_CAPACITY];
    }

    /// <summary>
    /// Add element to the ResizedStack
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If the element to add is equal to null</exception>
    /// <remarks>Double the size of this.elements if 
    /// there is no place for the element to add</remarks>
    /// <param name="value">Element (value) to be added</param>
    public void Push(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Element of the stack cannot be null.");
        }

        if (this.elements.Length <= this.count)
        {
            T[] resizedElements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, resizedElements, this.elements.Length);
            this.elements = resizedElements;
        }

        this.elements[this.count] = value;
        this.count++;
    }

    /// <summary>
    /// Delete last element in the ResizedStack
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// If the ResizedStack is empty</exception>
    /// <returns>Deleted element</returns>
    public T Pop()
    {
        if (count > 0)
        {
            T element = this.elements[this.count - 1];
            this.elements[this.count - 1] = default(T);
            this.count--;
            return element;
        }
        else
        {
            throw new InvalidOperationException(
                "Invalid operation! The stack is empty.");
        }
    }

    /// <summary>
    /// Select last element in the ResizedStack
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// If the ResizedStack is empty</exception>
    /// <returns>Selected element</returns>
    public T Peek()
    {
        if (count > 0)
        {
            T element = this.elements[this.count - 1];
            return element;
        }
        else
        {
            throw new InvalidOperationException(
                "Invalid operation! The stack is empty.");
        }
    }

    /// <summary>
    /// Check is given element (value) in the ResizedStack
    /// </summary>
    /// <param name="value">Element (value) to search</param>
    /// <exception cref="ArgumentNullException">
    /// If the element to search is equal to null</exception>
    /// <returns>True or False</returns>
    public bool Contains(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Element of the stack cannot be null.");
        }

        bool hasElement = false;
        for (int index = 0; index < this.count; index++)
        {
            if (this.elements[index].Equals(value))
            {
                hasElement = true;
                break;
            }
        }

        return hasElement;
    }

    /// <summary>
    /// Delete the elemets (values) in the ResizedStack
    /// </summary>
    /// <remarks>Replace them with default value 
    /// for the type of the elements</remarks>
    public void Clear()
    {
        this.elements = new T[this.elements.Length];
    }

    /// <summary>
    /// Cast the ResizedStack to array
    /// </summary>
    /// <returns>Array of elements in the ResizedStack</returns>
    public T[] ToArray()
    {
        return this.elements;
    }
}