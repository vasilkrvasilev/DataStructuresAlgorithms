using System;
using System.Collections.Generic;

public class EqualElements
{
    public static void Main()
    {
        // Read the elements of the sequence
        Console.WriteLine("Enter sequence elements");
        List<int> sequence = SortList.EnterSequence();

        // Find the max sequence of equal elements and print it
        List<int> maxSubsequence = FindMaxSequence(sequence);
        Console.WriteLine("The max subsequence of equal elements is:");
        foreach (int item in maxSubsequence)
        {
            Console.Write("{0} ", item);
        }
    }

    /// <summary>
    /// Find the sequence of equal elements with max length 
    /// </summary>
    /// <param name="sequence">The original sequence</param>
    /// <exception cref="ArgumentNullException">
    /// If the original sequence is null or empty</exception>
    /// <returns>The found sequence as List</returns>
    private static List<int> FindMaxSequence(List<int> sequence)
    {
        if (sequence == null || sequence.Count == 0)
        {
            throw new ArgumentNullException(
                "Invalid input! The sequence is empty.");
        }

        List<int> subsequence = new List<int>();
        List<int> maxSubsequence = new List<int>();
        subsequence.Add(sequence[0]);
        for (int index = 1; index < sequence.Count; index++)
        {
            if (sequence[index - 1] == sequence[index])
            {
                subsequence.Add(sequence[index]);
            }
            else
            {
                if (subsequence.Count > maxSubsequence.Count)
                {
                    maxSubsequence.Clear();
                    maxSubsequence.AddRange(subsequence);
                }

                subsequence.Clear();
                subsequence.Add(sequence[index]);
            }
        }

        if (subsequence.Count > maxSubsequence.Count)
        {
            maxSubsequence.Clear();
            maxSubsequence.AddRange(subsequence);
        }

        return maxSubsequence;
    }
}