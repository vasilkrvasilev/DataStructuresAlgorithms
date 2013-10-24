using System;
using System.Collections.Generic;
using System.Linq;

public class Queue
{
    public static void Main()
    {
        // Read the first element of the sequence and target value
        // Throw an exception if they are not a number or negative number
        Console.WriteLine("Enter positive number");
        uint start;
        string input = Console.ReadLine();
        bool isPositiveNumber = uint.TryParse(input, out start);
        if (!isPositiveNumber)
        {
            throw new ArgumentException(
                "Invalid input! You should enter positive integer number.");
        }

        Console.WriteLine("Enter positive number");
        uint end;
        input = Console.ReadLine();
        isPositiveNumber = uint.TryParse(input, out end);
        if (!isPositiveNumber || end <= start)
        {
            throw new ArgumentException(string.Format(
                "Invalid input! You should enter positive integer number bigger than {0}.", start));
        }

        // Find the sequence with min length from the first element of the sequence to target value
        List<uint> minSequence = FindMinSequence(start, end);
        Console.WriteLine("The min sequence elements are:");
        foreach (int item in minSequence)
        {
            Console.Write("{0} ", item);
        }
    }

    /// <summary>
    /// Find the sequence with min length from the first element of the sequence to target value
    /// </summary>
    /// <param name="start">The first element of the sequence</param>
    /// <param name="end">The target value</param>
    /// <remarks>Asume that the sequence could be ordered randomly
    /// for example - H+1, H+2, H*2, or H*2, H+1, H+2, but not
    /// H+1, H+2, H+2 or H+1, H+1, H*2</remarks>
    /// <returns>The sequence with min length</returns>
    public static List<uint> FindMinSequence(uint start, uint end)
    {
        List<List<uint>> output = new List<List<uint>>(6);
        List<uint> firstSequence = GenerateFirstSequence(start, end);
        output.Add(firstSequence);
        List<uint> secondSequence = GenerateSecondSequence(start, end);
        output.Add(secondSequence);
        List<uint> thirdSequence = GenerateThirdSequence(start, end);
        output.Add(thirdSequence);
        List<uint> fourthSequence = GenerateFourthSequence(start, end);
        output.Add(fourthSequence);
        List<uint> fifthSequence = GenerateFifthSequence(start, end);
        output.Add(fifthSequence);
        List<uint> sixthSequence = GenerateSixthSequence(start, end);
        output.Add(sixthSequence);
        int minLength = int.MaxValue;
        List<uint> minSequence = new List<uint>();
        foreach (var item in output)
        {
            if (item.Count < minLength)
            {
                minLength = item.Count;
                minSequence.Clear();
                minSequence.AddRange(item);
            }
        }

        return minSequence;
    }

    /// <summary>
    /// Generate the sequence with from the first element of the sequence 
    /// to target value with elements H+1, H+2, H*2
    /// </summary>
    /// <param name="start">The first element of the sequence</param>
    /// <param name="end">The target value</param>
    /// <returns>The sequence</returns>
    public static List<uint> GenerateFirstSequence(uint start, uint end)
    {
        Queue<uint> sequence = new Queue<uint>();
        List<uint> outputSequence = new List<uint>();
        sequence.Enqueue(start);
        while (sequence.Any(x => x <= end) && !outputSequence.Contains(end))
        {
            uint currentElement = sequence.Dequeue();
            outputSequence.Add(currentElement);
            sequence.Enqueue(currentElement + 1);
            sequence.Enqueue(currentElement + 3);
            sequence.Enqueue((currentElement + 3) * 2);
        }

        return outputSequence;
    }

    /// <summary>
    /// Generate the sequence with from the first element of the sequence 
    /// to target value with elements H+2, H+1, H*2
    /// </summary>
    /// <param name="start">The first element of the sequence</param>
    /// <param name="end">The target value</param>
    /// <returns>The sequence</returns>
    public static List<uint> GenerateSecondSequence(uint start, uint end)
    {
        Queue<uint> sequence = new Queue<uint>();
        List<uint> outputSequence = new List<uint>();
        sequence.Enqueue(start);
        while (sequence.Any(x => x <= end) && !outputSequence.Contains(end))
        {
            uint currentElement = sequence.Dequeue();
            outputSequence.Add(currentElement);
            sequence.Enqueue(currentElement + 2);
            sequence.Enqueue(currentElement + 3);
            sequence.Enqueue((currentElement + 3) * 2);
        }

        return outputSequence;
    }

    /// <summary>
    /// Generate the sequence with from the first element of the sequence 
    /// to target value with elements H+1, H*2, H+2
    /// </summary>
    /// <param name="start">The first element of the sequence</param>
    /// <param name="end">The target value</param>
    /// <returns>The sequence</returns>
    public static List<uint> GenerateThirdSequence(uint start, uint end)
    {
        Queue<uint> sequence = new Queue<uint>();
        List<uint> outputSequence = new List<uint>();
        sequence.Enqueue(start);
        while (sequence.Any(x => x <= end) && !outputSequence.Contains(end))
        {
            uint currentElement = sequence.Dequeue();
            outputSequence.Add(currentElement);
            sequence.Enqueue(currentElement + 1);
            sequence.Enqueue((currentElement + 1) * 2);
            sequence.Enqueue((currentElement + 1) * 2 + 2);
        }

        return outputSequence;
    }

    /// <summary>
    /// Generate the sequence with from the first element of the sequence 
    /// to target value with elements H*2, H+1, H+2
    /// </summary>
    /// <param name="start">The first element of the sequence</param>
    /// <param name="end">The target value</param>
    /// <returns>The sequence</returns>
    public static List<uint> GenerateFourthSequence(uint start, uint end)
    {
        Queue<uint> sequence = new Queue<uint>();
        List<uint> outputSequence = new List<uint>();
        sequence.Enqueue(start);
        while (sequence.Any(x => x <= end) && !outputSequence.Contains(end))
        {
            uint currentElement = sequence.Dequeue();
            outputSequence.Add(currentElement);
            sequence.Enqueue(currentElement * 2);
            sequence.Enqueue(currentElement * 2 + 1);
            sequence.Enqueue(currentElement * 2 + 3);
        }

        return outputSequence;
    }

    /// <summary>
    /// Generate the sequence with from the first element of the sequence 
    /// to target value with elements H+2, H*2, H+1
    /// </summary>
    /// <param name="start">The first element of the sequence</param>
    /// <param name="end">The target value</param>
    /// <returns>The sequence</returns>
    public static List<uint> GenerateFifthSequence(uint start, uint end)
    {
        Queue<uint> sequence = new Queue<uint>();
        List<uint> outputSequence = new List<uint>();
        sequence.Enqueue(start);
        while (sequence.Any(x => x <= end) && !outputSequence.Contains(end))
        {
            uint currentElement = sequence.Dequeue();
            outputSequence.Add(currentElement);
            sequence.Enqueue(currentElement + 2);
            sequence.Enqueue((currentElement + 2) * 2);
            sequence.Enqueue((currentElement + 2) * 2 + 1);
        }

        return outputSequence;
    }

    /// <summary>
    /// Generate the sequence with from the first element of the sequence 
    /// to target value with elements H*2, H+2, H+1
    /// </summary>
    /// <param name="start">The first element of the sequence</param>
    /// <param name="end">The target value</param>
    /// <returns>The sequence</returns>
    public static List<uint> GenerateSixthSequence(uint start, uint end)
    {
        Queue<uint> sequence = new Queue<uint>();
        List<uint> outputSequence = new List<uint>();
        sequence.Enqueue(start);
        while (sequence.Any(x => x <= end) && !outputSequence.Contains(end))
        {
            uint currentElement = sequence.Dequeue();
            outputSequence.Add(currentElement);
            sequence.Enqueue(currentElement * 2);
            sequence.Enqueue(currentElement * 2 + 2);
            sequence.Enqueue(currentElement * 2 + 3);
        }

        return outputSequence;
    }
}