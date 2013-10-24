using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class BiDictionary<K1, K2, T>
{
    private MultiDictionary<K1, T> firstKey;
    private MultiDictionary<K2, T> secondKey;
    private MultiDictionary<KeyValuePair<K1, K2>, T> bothKey;

    public BiDictionary(bool allowDuplicates)
    {
        this.firstKey = new MultiDictionary<K1, T>(allowDuplicates);
        this.secondKey = new MultiDictionary<K2, T>(allowDuplicates);
        this.bothKey = new MultiDictionary<KeyValuePair<K1, K2>, T>(allowDuplicates);
    }

    /// <summary>
    /// Add element to the BiDictionary
    /// </summary>
    /// <param name="firstKey">First key of the element</param>
    /// <param name="secondKey">Second key of the element</param>
    /// <param name="value">Value of the element</param>
    public void Add(K1 firstKey, K2 secondKey, T value)
    {
        this.firstKey.Add(firstKey, value);
        this.secondKey.Add(secondKey, value);
        this.bothKey.Add(new KeyValuePair<K1, K2>(firstKey, secondKey), value);
    }

    /// <summary>
    /// Add element with more than one values to the BiDictionary
    /// </summary>
    /// <param name="firstKey">First key of the element</param>
    /// <param name="secondKey">Second key of the element</param>
    /// <param name="value">Values of the element</param>
    public void AddMany(K1 firstKey, K2 secondKey, T[] value)
    {
        this.firstKey.AddMany(firstKey, value);
        this.secondKey.AddMany(secondKey, value);
        this.bothKey.AddMany(new KeyValuePair<K1, K2>(firstKey, secondKey), value);
    }

    /// <summary>
    /// Find the elements in the BiDictionary with given first key
    /// </summary>
    /// <param name="key">First key of the element</param>
    /// <returns>Collection of found elements</returns>
    public IEnumerable<KeyValuePair<K1, ICollection<T>>> FindByFirstKey(K1 key)
    {
        IEnumerable<KeyValuePair<K1, ICollection<T>>> found = 
            this.firstKey.FindAll(x => x.Key.Equals(key));
        return found;
    }

    /// <summary>
    /// Find the elements in the BiDictionary with given second key
    /// </summary>
    /// <param name="key">Second key of the element</param>
    /// <returns>Collection of found elements</returns>
    public IEnumerable<KeyValuePair<K2, ICollection<T>>> FindBySecondKey(K2 key)
    {
        IEnumerable<KeyValuePair<K2, ICollection<T>>> found =
            this.secondKey.FindAll(x => x.Key.Equals(key));
        return found;
    }

    /// <summary>
    /// Find the elements in the BiDictionary with given first and second key
    /// </summary>
    /// <param name="firstKey">First key of the element</param>
    /// <param name="secondKey">Second key of the element</param>
    /// <returns>Collection of found elements</returns>
    public IEnumerable<KeyValuePair<KeyValuePair<K1, K2>, ICollection<T>>> FindByBothKeys(K1 firstKey, K2 secondKey)
    {
        KeyValuePair<K1, K2> key = new KeyValuePair<K1, K2>(firstKey, secondKey);
        IEnumerable<KeyValuePair<KeyValuePair<K1, K2>, ICollection<T>>> found =
            this.bothKey.FindAll(x => x.Key.Equals(key));
        return found;
    }
}