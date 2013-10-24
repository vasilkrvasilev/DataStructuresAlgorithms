using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OddFrequencyElements
{
    public static void Main()
    {
        // Read the elements of the sequence and count the frequency of different numbers
        Console.WriteLine("Enter sequence elements");
        List<string> sequence = EnterSequence();
        Dictionary<string, int> differentElements = CountFrequency(sequence);
        List<string> oddFrequencyElements = new List<string>();

        // Find the nubers with odd frequency
        foreach (var item in differentElements)
        {
            if (item.Value % 2 != 0)
            {
                oddFrequencyElements.Add(item.Key);
            }
        }

        // Print the strings with odd frequency
        Console.WriteLine("The sequence elements with odd frequency are:");
        foreach (string item in oddFrequencyElements)
        {
            Console.WriteLine(item);
        }
    }

    /// <summary>
    /// Read the input elements and keep them as List
    /// </summary>
    /// <remarks>To end the sequence should enter white space</remarks>
    /// <returns>The result sequence</returns>
    public static List<string> EnterSequence()
    {
        List<string> sequence = new List<string>();
        string input = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(input))
        {
            sequence.Add(input);
            input = Console.ReadLine();
        }

        return sequence;
    }

    /// <summary>
    /// Extract all different strings from input sequence and count their frequency
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If the input sequence is null or empty</exception>
    /// <param name="sequence">The input sequence</param>
    /// <returns>Dictionary with key the string and value its frequency</returns>
    public static Dictionary<string, int> CountFrequency(List<string> sequence)
    {
        if (sequence == null || sequence.Count == 0)
        {
            throw new ArgumentNullException(
                "Invalid input! The sequence is empty.");
        }

        Dictionary<string, int> differentElements = new Dictionary<string, int>();
        foreach (var item in sequence)
        {
            if (differentElements.ContainsKey(item))
            {
                differentElements[item]++;
            }
            else
            {
                differentElements.Add(item, 1);
            }
        }

        return differentElements;
    }
}