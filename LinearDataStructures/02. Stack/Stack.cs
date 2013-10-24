using System;
using System.Collections.Generic;

public class Stack
{
    public static void Main()
    {
        // Keep the elements of the sequence in Stack<int>
        // Check is the element number
        // Throw exception if it is not
        Stack<int> sequence = new Stack<int>();
        Console.WriteLine("Enter sequence elements");
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

            sequence.Push(number);
            input = Console.ReadLine();
        }

        // Print the elements in reversed order
        Console.WriteLine("The reversed sequence is:");
        while (sequence.Count > 0)
        {
            int number = sequence.Pop();
            Console.Write("{0} ", number);
        }
    }
}