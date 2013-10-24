using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class Supermarket
{
    public static void Main()
    {
        Shop shop = new Shop();
        StringBuilder programResult = new StringBuilder();
        string command = Console.ReadLine();
        while (command != "End")
        {
            string commandResult = shop.ProcessCommand(command);
            programResult.AppendLine(commandResult);
            command = Console.ReadLine();
        }

        Console.WriteLine(programResult.ToString().TrimEnd());
    }
}

public class Shop
{
    private const string OK = "OK";
    private const string ERROR = "Error";

    private readonly BigList<string> queue;
    private readonly Dictionary<string, int> nameList;

    public Shop()
    {
        queue = new BigList<string>();
        nameList = new Dictionary<string, int>();
    }

    public string Append(string name)
    {
        queue.Add(name);
        if (nameList.ContainsKey(name))
        {
            nameList[name]++;
        }
        else
        {
            nameList.Add(name, 1);
        }

        return OK;
    }

    public string Insert(string position, string name)
    {
        int index = int.Parse(position);
        if (index >= 0 && index < queue.Count)
        {
            queue.Insert(index, name);
            if (nameList.ContainsKey(name))
            {
                nameList[name]++;
            }
            else
            {
                nameList.Add(name, 1);
            }

            return OK;
        }
        else if (index == queue.Count)
        {
            queue.Add(name);
            if (nameList.ContainsKey(name))
            {
                nameList[name]++;
            }
            else
            {
                nameList.Add(name, 1);
            }

            return OK;
        }
        else
        {
            return ERROR;
        }
    }

    public string Find(string name)
    {
        int found = 0;
        if (nameList.ContainsKey(name))
        {
            found = nameList[name];
        }

        return found.ToString();
    }

    public string Serve(string number)
    {
        int count = int.Parse(number);
        if (count <= queue.Count)
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < count; index++)
            {
                string current = queue[index];
                result.Append(current + " ");
                if (nameList[current] > 1)
                {
                    nameList[current]--;
                }
                else
                {
                    nameList.Remove(current);
                }
            }

            queue.RemoveRange(0, count);
            return result.ToString().TrimEnd();
        }
        else
        {
            return ERROR;
        }
    }

    public string ProcessCommand(string command)
    {
        string[] commandData = command.Split(' ');
        string result = string.Empty;
        if (commandData[0] == "Append")
        {
            result = Append(commandData[1]);
        }
        else if (commandData[0] == "Insert")
        {
            result = Insert(commandData[1], commandData[2]);
        }
        else if (commandData[0] == "Find")
        {
            result = Find(commandData[1]);
        }
        else if (commandData[0] == "Serve")
        {
            result = Serve(commandData[1]);
        }
        //else
        //{
        //    throw new ArgumentException("Invalid command");
        //}

        return result;
    }
}