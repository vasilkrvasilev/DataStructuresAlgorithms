using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Problem 01. Calculate the number of all possible binary combination
// of given input sequence of 0, 1 and * by replacing * with 0 or 1
public class BinaryCode
{
    public static void Main()
    {
        string input = Console.ReadLine();
        int inputLength = input.Length;
        string digits = input.Replace("*", string.Empty);
        int numberDigits = digits.Length;
        double numberAsterics = inputLength - numberDigits;
        double combinations = Math.Pow(2, numberAsterics);
        Console.WriteLine(combinations);
    }
}