using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        HashedSet<float> firstSet = new HashedSet<float>();
        firstSet.Add(1f);
        firstSet.Add(1.4f);
        firstSet.Add(1.7f);
        firstSet.Add(2f);
        firstSet.Add(2.2f);
        firstSet.Remove(1.7f);
        Console.WriteLine(firstSet.Find(1f));
        Console.WriteLine(firstSet.Count);

        HashedSet<float> secondSet = new HashedSet<float>();
        secondSet.Add(1f);
        secondSet.Add(2f);
        secondSet.Add(3f);
        secondSet.Add(5f);

        HashedSet<float> thirdSet = new HashedSet<float>();
        thirdSet.Add(1f);
        thirdSet.Add(2f);
        thirdSet.Add(3f);
        thirdSet.Add(5f);

        secondSet.Union(firstSet);
        thirdSet.Intersect(firstSet);
        firstSet.Clear();
    }
}