using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HashedSet<K>
{
    private HashTable<K, bool> innerSet;

    /// <summary>
    /// Returns the number of elements in the hashed set
    /// </summary>
    public int Count
    {
        get { return this.innerSet.Count; }
    }

    public HashedSet()
    {
        this.innerSet = new HashTable<K, bool>();
    }

    /// <summary>
    /// Find the value of the element with key equal to key from the hashed set
    /// </summary>
    /// <param name="key">Key of the element</param>
    /// <remarks>If there is no sush element in the hashed set returns false</remarks>
    /// <returns>True or False</returns>
    public bool Find(K key)
    {
        return this.innerSet.Find(key);
    }

    /// <summary>
    /// Insert new element with given key and value to the hashed set
    /// </summary>
    /// <param name="key">The key of the inserted element</param>
    /// <exception cref="InvalidOperationException">If there is already such element</exception>
    public void Add(K key)
    {
        this.innerSet.Add(key, true);
    }

    /// <summary>
    /// Remove element with given key from the hashed set
    /// </summary>
    /// <param name="key">Key of the element</param>
    /// <remarks>If there is no sush element, nothing is removed</remarks>
    public void Remove(K key)
    {
        this.innerSet.Remove(key);
    }

    /// <summary>
    /// Remove all elements from the hashed set
    /// </summary>
    public void Clear()
    {
        this.innerSet.Clear();
    }

    /// <summary>
    /// Add the elements from the input heshed set, which are not already in hashed set
    /// </summary>
    /// <param name="set">Input hashed set</param>
    public void Union(HashedSet<K> set)
    {
        foreach (var item in set.innerSet)
        {
            if (!this.innerSet.Find(item.Key))
            {
                this.innerSet.Add(item.Key, true);
            }
        }
    }

    /// <summary>
    /// Remove all element from hashed set, which are not in input hashed set
    /// </summary>
    /// <param name="set">Input hashed set</param>
    public void Intersect(HashedSet<K> set)
    {
        HashTable<K, bool> intersection = new HashTable<K, bool>();
        foreach (var item in set.innerSet)
        {
            bool isInBoth = set.innerSet.Find(item.Key) && this.innerSet.Find(item.Key);
            if (isInBoth)
            {
                intersection.Add(item.Key, true);
            }
        }

        this.innerSet = intersection;
    }
}