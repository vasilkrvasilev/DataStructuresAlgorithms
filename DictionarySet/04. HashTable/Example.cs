using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Example
{
    static void Main()
    {
        HashTable<string, double> table = new HashTable<string, double>();
        table.Add("a", 1.0);
        table.Add("aaa", 1.4);
        table.Add("z", 1.7);
        foreach (var item in table)
        {
            Console.WriteLine("{0} key {1} value", item.Key, item.Value);
        }

        table.Remove("a");
        Console.WriteLine(table.Find("aaa"));
        Console.WriteLine(table["z"]);
        Console.WriteLine(table.Count);
        List<string> keys = table.Keys();
        table.Clear();
    }
}