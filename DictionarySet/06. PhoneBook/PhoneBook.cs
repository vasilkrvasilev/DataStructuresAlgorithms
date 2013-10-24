using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PhoneBook
{
    private const string LINK = " from ";
    private const string COMMAND_NAME = "find";

    public static void Main()
    {
        // Generate phone book from file
        Console.WriteLine("Enter the name of the information file");   //phones.txt
        string bookFile = Console.ReadLine();
        Dictionary<string, List<string>> phoneBook =
            GeneratePhoneBook(bookFile);

        // Read commands from file and execute them
        Console.WriteLine("Enter the name of the command file");       //commands.txt
        string commandFile = Console.ReadLine();
        HandleCommands(commandFile, phoneBook);
    }

    /// <summary>
    /// Read file and add element to the phone book (name and town with phones)
    /// </summary>
    /// <param name="file">File name</param>
    /// <remarks>Use UTF-8 encoding</remarks>
    /// <returns>Created phone book</returns>
    public static Dictionary<string, List<string>> GeneratePhoneBook(string file)
    {
        Dictionary<string, List<string>> phoneBook = 
            new Dictionary<string, List<string>>();
        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] content = line.Split('|');
                string town = content[1].Trim().ToLower();
                string name = content[0].Trim().ToLower();
                string phone = content[2].Trim();
                AddToPhoneBook(phoneBook, town, name, phone);
                line = reader.ReadLine();
            }
        }

        return phoneBook;
    }

    /// <summary>
    /// Add element to input phone book (name and town with phones)
    /// </summary>
    /// <param name="phoneBook">Input phone book</param>
    /// <param name="town">Town of the element</param>
    /// <param name="name">Name of the element</param>
    /// <param name="phone">Phone of the element</param>
    /// <remarks>For Ivan Ivanov Sofia the method will add four element:
    /// Ivan, Ivanov, Ivan from Sofia, Ivanov from Sofia</remarks>
    private static void AddToPhoneBook(Dictionary<string, List<string>> phoneBook, string town, string name, string phone)
    {
        string[] allNames = name.Split(' ');
        foreach (var item in allNames)
        {
            if (phoneBook.ContainsKey(item))
            {
                phoneBook[item].Add(phone);
            }
            else
            {
                List<string> phoneList = new List<string>();
                phoneList.Add(phone);
                phoneBook.Add(item, phoneList);
            }

            if (phoneBook.ContainsKey(item + LINK + town))
            {
                phoneBook[item + LINK + town].Add(phone);
            }
            else
            {
                List<string> phoneList = new List<string>();
                phoneList.Add(phone);
                phoneBook.Add(item + LINK + town, phoneList);
            }
        }
    }

    /// <summary>
    /// Read commands (find) from file and execute them searching in given phone book
    /// </summary>
    /// <param name="file">File name</param>
    /// <param name="phoneBook">Phone book to search in</param>
    /// <remarks>Use UTF-8 encoding</remarks>
    /// <exception cref="InvalidOperationException">If current command is invalid</exception>
    public static void HandleCommands(string file, Dictionary<string, List<string>> phoneBook)
    {
        char[] separators = new char[] { ',', '(', ')' };
        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] content = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (content.Length > 1 && content[0] == COMMAND_NAME)
                {
                    if (content.Length == 2)
                    {
                        string name = content[1].Trim().ToLower();
                        FindPhones(name, phoneBook);
                    }
                    else if (content.Length == 3)
                    {
                        string name = content[1].Trim().ToLower();
                        string town = content[2].Trim().ToLower();
                        FindPhones(name + LINK + town, phoneBook);
                    }
                }
                else
                {
                    throw new InvalidOperationException(
                        "Invalid input! You enter invalid command. Valid command format: find(name) and find(name, town)");
                }

                line = reader.ReadLine();
            }
        }
    }

    /// <summary>
    /// Find a name in the phone book and print all phones connected with it
    /// </summary>
    /// <param name="key">Name to search</param>
    /// <param name="phoneBook">Phone book to search in</param>
    private static void FindPhones(string key, Dictionary<string, List<string>> phoneBook)
    {
        if (phoneBook.ContainsKey(key))
        {
            List<string> phones = phoneBook[key];
            Console.WriteLine("{0} match next phone numbers:", key);
            foreach (var phone in phones)
            {
                Console.WriteLine("\t{0}", phone);
            }
        }
        else
        {
            Console.WriteLine("{0} not found", key);
        }
    }
}