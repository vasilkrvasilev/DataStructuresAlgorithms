using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PermutationWithRepetitions
{
    static int[] sequence;

    static void Main()
    {
        ReadSequence();
        Array.Sort(sequence);

        // Start recursion
        Permutate(0, sequence.Length);
    }

    private static void ReadSequence()
    {
        Console.WriteLine("Enter number of elements");
        int elements = int.Parse(Console.ReadLine());
        sequence = new int[elements];
        Console.WriteLine("Enter elements");
        for (int count = 0; count < elements; count++)
		{
			 sequence[count] = int.Parse(Console.ReadLine());
		}
    }

    public static void Permutate(int start, int end)
    {
        Print();
        int exchange = 0;
        if (start < end)
        {
            for (int index = end - 2; index >= start; index--)
            {
                for (int count = index + 1; count < end; count++)
                {
                    // Bottom of recursion
                    if (sequence[index] != sequence[count])
                    {
                        // Swap sequence[index] <--> sequence[count]
                        exchange = sequence[index];
                        sequence[index] = sequence[count];
                        sequence[count] = exchange;

                        Permutate(index + 1, end);
                    }
                }

                // Undo all modifications done by recursive calls and swapping
                exchange = sequence[index];
                for (int count = index; count < end - 1; )
                {
                    sequence[count] = sequence[++count];
                }

                sequence[end - 1] = exchange;
            }
        }
    }

    private static void Print()
    {
        for (int count = 0; count < sequence.Length; count++)
        {
            Console.Write("{0} ", sequence[count]);
        }

        Console.WriteLine();
    }
}