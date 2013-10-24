using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class WordFrequency
{
    public static void Main()
    {
        // Extract different words, count their frequency and order them by it
        Console.WriteLine("Enter file name");   //text.txt
        string file = Console.ReadLine();
        Dictionary<string, int> wordFrequency = CountFrequency(file);
        IEnumerable<KeyValuePair<string, int>> sorted = wordFrequency.OrderBy(pair => pair.Value);

        // Print the numbers and their frequency
        Console.WriteLine("The sorted words by their frequency:");
        foreach (var word in sorted)
        {
            Console.WriteLine("{0} -> {1} times", word.Key, word.Value);
        }
    }

    /// <summary>
    /// Extract different words from given file and count their frecuency
    /// </summary>
    /// <remarks>Separate words by this symbols:
    /// ' ', ',', '.', '!', '?', ':', ';', '-', '(', ')', '\n', '\r'.
    /// Use UTF-8 encoding.</remarks>
    /// <param name="file">Name of the file</param>
    /// <exception cref="ArgumentNullException">
    /// If the file name is null or whitespace</exception>
    /// <returns>Collection (Dictionary) of different words and their frecuency</returns>
    public static Dictionary<string, int> CountFrequency(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            throw new ArgumentNullException(
                "Invalid input! The file name cannot be empty or white space.");
        }

        char[] separators = new char[]{' ', ',', '.', '!', '?', ':', ';', '-', '(', ')', '\n', '\r'};
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] content = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int count = 0; count < content.Length; count++)
                {
                    string word = content[count].ToLower();
                    if (wordFrequency.ContainsKey(word))
                    {
                        wordFrequency[word]++;
                    }
                    else
                    {
                        wordFrequency.Add(word, 1);
                    }
                }

                line = reader.ReadLine();
            }
        }

        return wordFrequency;
    }
}