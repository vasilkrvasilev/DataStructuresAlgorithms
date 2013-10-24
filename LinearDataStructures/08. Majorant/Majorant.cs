using System;
using System.Collections.Generic;

public class Majorant
{
    public static void Main()
    {
        // Read the elements of the sequence and count the frequency of different numbers
        Console.WriteLine("Enter sequence elements");
        List<int> sequence = SortList.EnterSequence();
        Dictionary<int, int> differentNumbers = RemoveOdd.CountFrequency(sequence);

        // Find the majorants in the sequence
        List<int> majorants = new List<int>();
        int length = sequence.Count;
        foreach (var item in differentNumbers)
        {
            if (item.Value >= (length / 2) + 1)
            {
                majorants.Add(item.Key);
            }
        }

        // Print the majorants in the sequence
        Console.WriteLine("The majorants in the sequence are:");
        if (majorants.Count == 0)
        {
            Console.WriteLine("There are no majorants in the sequence");
        }
        else
        {
            foreach (int item in majorants)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}