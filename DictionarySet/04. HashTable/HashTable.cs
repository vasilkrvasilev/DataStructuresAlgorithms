using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
{
    private const int INITIAL_CAPACITY = 16;
    private const float LOAD_CAPACITY = 0.75f;

    private LinkedList<KeyValuePair<K, T>>[] elements;
    private int elementsCount;
    private int count;

    /// <summary>
    /// Returns the number of elements in the hash table
    /// </summary>
    public int Count
    {
        get { return this.elementsCount; }
    }

    public HashTable()
    {
        this.elements = new LinkedList<KeyValuePair<K, T>>[INITIAL_CAPACITY];
        this.elementsCount = 0;
        this.count = 0;
    }

    /// <summary>
    /// Return the index of the element with key equal to key in this.elements
    /// </summary>
    /// <param name="key">Key of the element</param>
    /// <returns>Index in this.elements</returns>
    private int GetIndex(K key)
    {
        int index = Math.Abs(key.GetHashCode()) % this.elements.Length;
        return index;
    }

    /// <summary>
    /// Double the length of this.elements of load capacity is bigger than LOAD_CAPACITY
    /// </summary>
    private void Resize()
    {
        if ((float)this.count / this.elements.Length > LOAD_CAPACITY)
        {
            LinkedList<KeyValuePair<K, T>>[] oldTable = this.elements;
            this.elements = new LinkedList<KeyValuePair<K, T>>[oldTable.Length * 2];
            foreach (var list in oldTable)
            {
                foreach (var node in list)
                {
                    this.Add(node.Key, node.Value);
                }
            }
        }
    }

    /// <summary>
    /// Find the value of the element with key equal to key from the hash table
    /// </summary>
    /// <param name="key">Key of the element</param>
    /// <remarks>If there is no sush element in the hash table returns default(T)</remarks>
    /// <returns>Value of the element</returns>
    public T Find(K key)
    {
        T value = default(T);
        bool isFound = false;
        int index = this.GetIndex(key);
        if (this.elements[index] != null)
        {
            foreach (var node in this.elements[index])
            {
                if (node.Key.Equals(key))
                {
                    value = node.Value;
                    isFound = true;
                    break;
                }
            }
        }

        return value;
    }

    /// <summary>
    /// Insert new element with given key and value to the hash table
    /// </summary>
    /// <param name="key">The key of the inserted element</param>
    /// <param name="value">The value of the inserted element</param>
    /// <exception cref="InvalidOperationException">If there is already such element</exception>
    public void Add(K key, T value)
    {
        int index = this.GetIndex(key);
        if (this.elements[index] == null)
        {
            LinkedList<KeyValuePair<K, T>> list = new LinkedList<KeyValuePair<K, T>>();
            KeyValuePair<K, T> pair = new KeyValuePair<K, T>(key, value);
            list.AddFirst(new LinkedListNode<KeyValuePair<K, T>>(pair));
            this.elements[index] = list;
            this.elementsCount++;
            this.count++;
            this.Resize();
        }
        else
        {
            if (this.elements[index].Find(new KeyValuePair<K, T>(key, value)) == null)
            {
                KeyValuePair<K, T> pair = new KeyValuePair<K, T>(key, value);
                this.elements[index].AddFirst(new LinkedListNode<KeyValuePair<K, T>>(pair));
                this.elementsCount++;
            }
            else
            {
                throw new InvalidOperationException("The element is already added.");
            }
        }
    }

    /// <summary>
    /// Remove element with given key from the hash table
    /// </summary>
    /// <param name="key">Key of the element</param>
    /// <remarks>If there is no sush element, nothing is removed</remarks>
    public void Remove(K key)
    {
        int index = this.GetIndex(key);
        if (this.elements[index] != null)
        {
            foreach (var node in this.elements[index])
            {
                if (node.Key.Equals(key))
                {
                    this.elements[index].Remove(node);
                    this.elementsCount--;
                    break;
                }
            }

            if (this.elements[index].Count == 0)
            {
                this.elements[index] = null;
                this.count--;
            }
        }
    }

    /// <summary>
    /// Remove all elements from the hash table
    /// </summary>
    public void Clear()
    {
        this.elements = new LinkedList<KeyValuePair<K, T>>[this.elements.Length];
        this.elementsCount = 0;
        this.count = 0;
    }

    /// <summary>
    /// Select keys of all elements in the hash table
    /// </summary>
    /// <returns>Collection (List) of selected keys</returns>
    public List<K> Keys()
    {
        List<K> keys = new List<K>();
        foreach (var list in this.elements)
        {
            if (list != null)
            {
                foreach (var node in list)
                {
                    keys.Add(node.Key);
                }
            }
        }

        return keys;
    }

    /// <summary>
    /// Return the value of element with given key or
    /// set its value if there is sush element in the hash table
    /// </summary>
    /// <param name="key">Key of the element</param>
    /// <returns>Value of the element</returns>
    public T this[K key]
    {
        get
        {
            return this.Find(key);
        }
        set
        {
            KeyValuePair<K, T> pair = new KeyValuePair<K, T>();
            int index = this.GetIndex(key);
            if (this.elements[index] != null)
            {
                foreach (var node in this.elements[index])
                {
                    if (node.Key.Equals(key))
                    {
                        pair = node;
                        break;
                    }
                }
            }

            pair = new KeyValuePair<K, T>(key, value);
        }
    }

    /// <summary>
    /// Implement IEnumerable interface
    /// </summary>
    /// <returns>Each of elements in the hash table</returns>
    public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
    {
        foreach (var list in this.elements)
        {
            if (list != null)
            {
                foreach (var node in list)
                {
                    yield return node;
                }
            }
        }
    }

    /// <summary>
    /// Implement IEnumerable interface
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}