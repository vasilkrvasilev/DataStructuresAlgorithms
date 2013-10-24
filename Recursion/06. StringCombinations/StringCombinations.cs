using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StringCombinations
{
    static List<string> sequence = new List<string>();
    static List<string> subset = new List<string>();

    public static void Main()
    {
        ReadSequence();
        int number = sequence.Count;
        int elements = NestedLoops.ReadInput("Enter number elements in the combination");

        // Start recursion
        PrintSequence(1, elements, 0, number);
    }

    private static void ReadSequence()
    {
        Console.WriteLine("Enter elements");
        string input = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(input))
        {
            sequence.Add(input);
            input = Console.ReadLine();
        }
    }

    private static void PrintSequence(int currentElement, int elements, int currentNumber, int number)
    {
        // Bottom of recursion
        if (currentElement > elements)
        {
            return;
        }

        // Process current element
        for (int index = currentNumber; index < number; index++)
        {
            subset.Add(sequence[index]);
            PrintSequence(currentElement + 1, elements, index + 1, number);
            if (subset.Count == elements)
            {
                foreach (var item in subset)
                {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine();
            }

            subset.RemoveAt(subset.Count - 1);
        }
    }
}