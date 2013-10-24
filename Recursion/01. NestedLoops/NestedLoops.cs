using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NestedLoops
{
    static List<int> sequence = new List<int>();

    public static void Main()
    {
        int elements = ReadInput("Enter number");

        // Start recursion
        PrintSequence(1, elements);
    }

    public static int ReadInput(string message)
    {
        Console.WriteLine(message);
        int number;
        string input = Console.ReadLine();
        bool isNumber = int.TryParse(input, out number);
        while (!isNumber || number < 0)
        {
            Console.WriteLine("You enter invalid or negative number. Please try again.");
            input = Console.ReadLine();
            isNumber = int.TryParse(input, out number);
        }

        return number;
    }

    private static void PrintSequence(int currentElement, int elements)
    {
        // Bottom of recursion
        if (currentElement > elements)
        {
            return;
        }

        // Process current element
        for (int index = 1; index <= elements; index++)
        {
            sequence.Add(index);
            PrintSequence(currentElement + 1, elements);
            if (sequence.Count == elements)
            {
                foreach (var item in sequence)
                {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine();
            }

            sequence.RemoveAt(sequence.Count - 1);
        }
    }
}