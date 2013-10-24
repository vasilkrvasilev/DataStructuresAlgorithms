using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        // Generate trie from file
        ITrie trie = TrieFactory.GetTrie();
        Console.WriteLine("Enter the name of the information file");   //text.txt
        string trieFile = Console.ReadLine();
        char[] separators = new char[] { ' ', '\t', ',', '.', '!', '?' };
        StreamReader trieReader = new StreamReader(trieFile, Encoding.GetEncoding("UTF-8"));
        using (trieReader)
        {
            string line = trieReader.ReadLine();
            while (line != null)
            {
                string[] content = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in content)
                {
                    trie.AddWord(word);
                }

                line = trieReader.ReadLine();
            }
        }

        // Read commands from file and execute them
        Console.WriteLine("Enter the name of the command file");       //words.txt
        string commandFile = Console.ReadLine();
        StreamReader reader = new StreamReader(commandFile, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string word = line.Trim();
                Console.WriteLine("{0} -> {1} times", word, trie.WordCount(word));

                line = reader.ReadLine();
            }
        }
    }
}