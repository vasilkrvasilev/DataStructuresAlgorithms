using System;
using System.Collections.Generic;

public class SortList
{
    public static void Main()
    {
        // Read the elements of the sequence
        Console.WriteLine("Enter sequence elements");
        List<int> sequence = EnterSequence();

        // Sort and print it
        sequence.Sort();
        Console.WriteLine("The sorted sequence is:");
        foreach (int item in sequence)
        {
            Console.Write("{0} ", item);
        }
    }

    /// <summary>
    /// Read the input elements and keep them as List
    /// </summary>
    /// <exception cref="ArgumentException">
    /// If input element is not a number</exception>
    /// <remarks>To end the sequence should enter white space</remarks>
    /// <returns>The result sequence</returns>
    public static List<int> EnterSequence()
    {
        List<int> sequence = new List<int>();
        string input = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(input))
        {
            int number;
            bool isNumber = int.TryParse(input, out number);
            if (!isNumber)
            {
                throw new ArgumentException(
                    "Invalid input! You should enter integer number.");
            }

            sequence.Add(number);
            input = Console.ReadLine();
        }

        return sequence;
    }
}