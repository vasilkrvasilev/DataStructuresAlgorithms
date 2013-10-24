using System;
using System.Collections.Generic;

public class CountFrequency
{
    public static void Main()
    {
        // Read the elements of the sequence and count the frequency of different numbers
        Console.WriteLine("Enter sequence elements");
        List<int> sequence = SortList.EnterSequence();
        Dictionary<int, int> differentNumbers = RemoveOdd.CountFrequency(sequence);

        // Print the numbers in the interval [0, 1000] and their frequency
        Console.WriteLine("The frecuency of the elements is:");
        foreach (var item in differentNumbers)
        {
            if (item.Key < 0 || item.Key > 1000)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}