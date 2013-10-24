using System;
using System.Collections.Generic;

public class QueueSequence
{
    public static void Main()
    {
        // Read the first element of the sequence
        // Throw an exception if the first elements is not a number or negative number
        Console.WriteLine("Enter positive number");
        int elementsToPrint = 50;
        uint number;
        string input = Console.ReadLine();
        bool isPositiveNumber = uint.TryParse(input, out number);
        if (!isPositiveNumber)
        {
            throw new ArgumentException(
                "Invalid input! You should enter positive integer number.");
        }

        // Calculate and print the first elementsToPrint on the console
        Queue<uint> sequence = new Queue<uint>();
        sequence.Enqueue(number);
        int count = 1;
        while (count <= elementsToPrint)
        {
            uint currentElement = sequence.Dequeue();
            Console.Write("{0} ", currentElement);

            sequence.Enqueue(currentElement + 1);
            sequence.Enqueue(2 * currentElement + 1);
            sequence.Enqueue(currentElement + 2);
            count++;
        }
    }
}