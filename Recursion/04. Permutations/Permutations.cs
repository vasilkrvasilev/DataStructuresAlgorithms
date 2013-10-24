using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Permutations
{
    static List<int> sequence = new List<int>();

    public static void Main()
    {
        int elements = NestedLoops.ReadInput("Enter number");

        // Start recursion
        PrintSequence(1, elements);
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
            if (!sequence.Contains(index))
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
}