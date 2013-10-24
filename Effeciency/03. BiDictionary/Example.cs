using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        BiDictionary<int, double, string> biDictionary = new BiDictionary<int, double, string>(true);
        biDictionary.Add(1, 1.1, "a");
        biDictionary.AddMany(2, 2.4, new string[] { "c", "d", "e" });
        biDictionary.Add(3, 3.3, "z");
        var firstFound = biDictionary.FindByFirstKey(2);
        foreach (var item in firstFound)
        {
            Console.WriteLine("{0} key {1} value", item.Key, item.Value);
        }

        var secondFound = biDictionary.FindBySecondKey(1.1);
        foreach (var item in secondFound)
        {
            Console.WriteLine("{0} key {1} value", item.Key, item.Value);
        }

        var bothFound = biDictionary.FindByBothKeys(3, 3.3);
        foreach (var item in bothFound)
        {
            Console.WriteLine("{0} key {1} value", item.Key, item.Value);
        }
    }
}