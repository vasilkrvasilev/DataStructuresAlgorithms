using System;
using System.Collections.Generic;

public class RemoveOdd
{
    public static void Main()
    {
        // Read the elements of the sequence and count the frequency of different numbers
        Console.WriteLine("Enter sequence elements");
        List<int> sequence = SortList.EnterSequence();
        Dictionary<int, int> differentNumbers = CountFrequency(sequence);

        // Remove the nubers with odd frequency
        foreach (var item in differentNumbers)
        {
            if (item.Value % 2 != 0)
            {
                sequence.RemoveAll(x => x == item.Key);
            }
        }

        // Print the numbers with even frequency
        Console.WriteLine("The sequence elements are:");
        foreach (int item in sequence)
        {
            Console.Write("{0} ", item);
        }
    }

    /// <summary>
    /// Extract all different numbers from input sequence and count their frequency
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If the input sequence is null or empty</exception>
    /// <param name="sequence">The input sequency</param>
    /// <returns>Dictionary with key the number and value its frequency</returns>
    public static Dictionary<int, int> CountFrequency(List<int> sequence)
    {
        if (sequence == null || sequence.Count == 0)
        {
            throw new ArgumentNullException(
                "Invalid input! The sequence is empty.");
        }

        Dictionary<int, int> differentNumbers = new Dictionary<int, int>();
        foreach (var item in sequence)
        {
            if (differentNumbers.ContainsKey(item))
            {
                differentNumbers[item]++;
            }
            else
            {
                differentNumbers.Add(item, 1);
            }
        }

        return differentNumbers;
    }
}