using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Combinations
{
    static List<int> sequence = new List<int>();

    public static void Main()
    {
        int number = NestedLoops.ReadInput("Enter number");
        int elements = NestedLoops.ReadInput("Enter number elements in the combination");

        // Start recursion
        PrintSequence(1, elements, 1, number);
    }

    private static void PrintSequence(int currentElement, int elements, int currentNumber, int number)
    {
        // Bottom of recursion
        if (currentElement > elements)
        {
            return;
        }

        // Process current element
        for (int index = currentNumber; index <= number; index++)
        {
            sequence.Add(index);
            PrintSequence(currentElement + 1, elements, index, number);
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