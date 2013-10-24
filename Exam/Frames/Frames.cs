using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Frames
{
    static List<string> sequence = new List<string>();
    static bool[] used;
    static List<List<byte>> coupleList = new List<List<byte>>();
    static SortedSet<string> result = new SortedSet<string>();

    public static void Main()
    {
        int numberCouples = int.Parse(Console.ReadLine());
        used = new bool[numberCouples];
        //List<List<byte>> coupleList = new List<List<byte>>();
        for (int count = 0; count < numberCouples; count++)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<byte> couple = new List<byte>();
            couple.Add(byte.Parse(input[0]));
            couple.Add(byte.Parse(input[1]));
            couple.Sort();
            coupleList.Add(couple);
        }

        coupleList.Sort(new CoupleComparer());
        PrintSequence(0, coupleList.Count);
        StringBuilder programResult = new StringBuilder();
        programResult.AppendLine(result.Count.ToString());
        foreach (var item in result)
        {
            programResult.AppendLine(item);
        }

        Console.WriteLine(programResult.ToString().TrimEnd());
    }

    private static void PrintSequence(int currentElement, int elements)
    {
        // Bottom of recursion
        if (currentElement > elements)
        {
            return;
        }

        // Process current element
        for (int index = 0; index < elements; index++)
        {
            //string currentCouple = string.Format("({0}, {1})", coupleList[index][0], coupleList[index][1]);
            if (!used[index])
            {
                string currentCouple = string.Format("({0}, {1})", coupleList[index][0], coupleList[index][1]);
                sequence.Add(currentCouple);
                used[index] = true;
                PrintSequence(currentElement + 1, elements);
                if (sequence.Count == elements)
                {
                    StringBuilder currentSequence = new StringBuilder();
                    for (int count = 0; count < sequence.Count - 1; count++)
                    {
                        currentSequence.Append(sequence[count] + " | ");
                    }

                    currentSequence.Append(sequence[sequence.Count - 1]);
                    if (!result.Contains(currentSequence.ToString()))
                    {
                        result.Add(currentSequence.ToString());
                    }
                }

                used[index] = false;
                sequence.RemoveAt(sequence.Count - 1);
            }

            //currentCouple = string.Format("({0}, {1})", coupleList[index][1], coupleList[index][0]);
            if (!used[index])
            {
                string currentCouple = string.Format("({0}, {1})", coupleList[index][1], coupleList[index][0]);
                sequence.Add(currentCouple);
                used[index] = true;
                PrintSequence(currentElement + 1, elements);
                if (sequence.Count == elements)
                {
                    StringBuilder currentSequence = new StringBuilder();
                    for (int count = 0; count < sequence.Count - 1; count++)
                    {
                        currentSequence.Append(sequence[count] + " | ");
                    }

                    currentSequence.Append(sequence[sequence.Count - 1]);
                    if (!result.Contains(currentSequence.ToString()))
                    {
                        result.Add(currentSequence.ToString());
                    }
                }

                used[index] = false;
                sequence.RemoveAt(sequence.Count - 1);
            }
        }
    }
}

public class CoupleComparer : IComparer<List<byte>>
{
    public int Compare(List<byte> x, List<byte> y)
    {
        string xAsString = string.Format("{0}{1}", x[0], x[1]);
        string yAsString = string.Format("{0}{1}", y[0], y[1]);

        return xAsString.CompareTo(yAsString);
    }
}