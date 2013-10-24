using System;

public class MinimumEditDistance
{
    static void Main()
    {
        // Read the input
        Console.WriteLine("Enter first word");
        string firstWord = Console.ReadLine();
        Console.WriteLine("Enter second word");
        string secondWord = Console.ReadLine();
        Console.WriteLine("Enter cost to replace a letter");
        double replace = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter cost to delete a letter");
        double delete = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter cost to insert a letter");
        double insert = double.Parse(Console.ReadLine());

        // Compute the minimum edit distance between two words
        double solution = LevenshteinDistance.Compute(firstWord, secondWord, replace, delete, insert);
        Console.WriteLine(solution);

        //Console.WriteLine(LevenshteinDistance.Compute("aunt", "ant", 1, 0.9, 0.8));
        //Console.WriteLine(LevenshteinDistance.Compute("Sam", "Samantha", 1, 0.9, 0.8));
        //Console.WriteLine(LevenshteinDistance.Compute("flomax", "volmax", 1, 0.9, 0.8));
    }
}