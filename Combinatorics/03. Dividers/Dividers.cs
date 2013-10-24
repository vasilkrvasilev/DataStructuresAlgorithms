using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Generate all numbers from given digits without repetitions and find the number with least dividers
public class Dividers
{
    static int[] digits;
    static bool[] used;
    static int[] currentNumber;
    static SortedDictionary<int, int> generatedNumbers = new SortedDictionary<int, int>();

    public static void Main()
    {
        // Read the input
        int numberDigits = int.Parse(Console.ReadLine());
        digits = new int[numberDigits];
        used = new bool[numberDigits];
        currentNumber = new int[numberDigits];
        for (int count = 0; count < numberDigits; count++)
        {
            digits[count] = int.Parse(Console.ReadLine());
        }

        // Start recursion
        GenerateNumber(0);
        Console.WriteLine(generatedNumbers.First().Value);
    }

    static void GenerateNumber(int index)
    {
        // If all digits are used save generated number
        if (index >= digits.Length)
        {
            AddNumber();
        }
        else
        {
            // Choose next unused digit and add it to currentNumber
            for (int count = 0; count < digits.Length; count++)
            {
                if (!used[count])
                {
                    used[count] = true;
                    currentNumber[index] = digits[count];
                    GenerateNumber(index + 1);
                    used[count] = false;
                }
            }
        }
    }

    private static void AddNumber()
    {
        // Conver currentNumber to integer number
        int number = 0;
        for (int count = digits.Length - 1; count >= 0; count--)
        {
            number += currentNumber[count] * (int)Math.Pow(10, digits.Length - 1 - count);
        }

        // Count its dividers and check if there is another number with same number of dividers
        // If it is so save the smaller one, else just save the number
        int numberDividers = CountDividers(number);
        if (generatedNumbers.ContainsKey(numberDividers))
        {
            if (generatedNumbers[numberDividers] > number)
            {
                generatedNumbers[numberDividers] = number;
            }
        }
        else
        {
            generatedNumbers.Add(numberDividers, number);
        }
    }

    private static int CountDividers(int number)
    {
        // Find all diivders of the number searching in the interval [2, number / 2]
        int maxDivider = number / 2;
        int numberDividers = 0;
        for (int divider = 2; divider <= maxDivider; divider++)
        {
            if (number % divider == 0)
            {
                numberDividers++;
            }
        }

        return numberDividers;
    }
}