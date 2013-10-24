using System;
using System.Collections.Generic;

public class RemoveNegativeNumbers
{
    public static void Main()
    {
        // Read the elements of the sequence
        Console.WriteLine("Enter sequence elements");
        List<int> sequence = SortList.EnterSequence();

        // First way to remove negative numbers
        sequence.RemoveAll(x => x < 0);

        // Second way to remove negative numbers
        //foreach (var item in sequence)
        //{
        //    if (item < 0)
        //    {
        //        sequence.Remove(item);
        //    }
        //}

        // Print the result sequence
        Console.WriteLine("The sequence elements are:");
        foreach (int item in sequence)
        {
            Console.Write("{0} ", item);
        }
    }
}