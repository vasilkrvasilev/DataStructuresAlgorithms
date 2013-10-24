using System;
using System.Collections.Generic;

public class ListSequence
{
    public static void Main()
    {
        // Keep the elements of the sequence in List<uint>
        // Check is the element positive number
        // Throw exception if it is not
        List<uint> sequence = new List<uint>();
        long sum = 0;
        Console.WriteLine("Enter sequence elements");
        string input = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(input))
        {
            uint number;
            bool isPositiveNumber = uint.TryParse(input, out number);
            if (!isPositiveNumber)
            {
                throw new ArgumentException(
                    "Invalid input! You should enter positive integer number.");
            }

            sequence.Add(number);
            sum += number;
            input = Console.ReadLine();
        }

        Console.WriteLine("The sum of the sequence is: {0}", sum);
        Console.WriteLine("The average of the sequence is: {0}", (double)sum/sequence.Count);
    }
}