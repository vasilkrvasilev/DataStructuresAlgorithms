using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class ElementFrequency
{
    public static void Main()
    {
        // Read the elements of the sequence and count the frequency of different numbers
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.WriteLine("Enter sequence elements");
        List<double> sequence = EnterSequence();
        Dictionary<double, int> differentNumbers = CountFrequency(sequence);

        // To sort differentNumbers by key should use sortedNumbers
        //SortedDictionary<int, int> sortedNumbers = new SortedDictionary<int, int>(differentNumbers);

        // Print the numbers and their frequency
        Console.WriteLine("The sequence elements and their frequency:");
        foreach (var number in differentNumbers)
        {
            Console.WriteLine("{0} -> {1} times", number.Key, number.Value);
        }
    }

    /// <summary>
    /// Read the input elements and keep them as List
    /// </summary>
    /// <exception cref="ArgumentException">
    /// If input element is not a number</exception>
    /// <remarks>To end the sequence should enter white space</remarks>
    /// <returns>The result sequence</returns>
    public static List<double> EnterSequence()
    {
        List<double> sequence = new List<double>();
        string input = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(input))
        {
            double number;
            bool isNumber = double.TryParse(input, out number);
            if (!isNumber)
            {
                throw new ArgumentException(
                    "Invalid input! You should enter number.");
            }

            sequence.Add(number);
            input = Console.ReadLine();
        }

        return sequence;
    }

    /// <summary>
    /// Extract all different numbers from input sequence and count their frequency
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If the input sequence is null or empty</exception>
    /// <param name="sequence">The input sequency</param>
    /// <returns>Dictionary with key the number and value its frequency</returns>
    public static Dictionary<double, int> CountFrequency(List<double> sequence)
    {
        if (sequence == null || sequence.Count == 0)
        {
            throw new ArgumentNullException(
                "Invalid input! The sequence is empty.");
        }

        Dictionary<double, int> differentElements = new Dictionary<double, int>();
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