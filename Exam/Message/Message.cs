using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Message
{
    public static void Main()
    {
        int numberMessages = int.Parse(Console.ReadLine());
        string[] messages = new string[numberMessages];
        List<char> combine = new List<char>();
        for (int count = 0; count < numberMessages; count++)
        {
            string current = Console.ReadLine();
            messages[count] = current;
            for (int letter = 0; letter < current.Length; letter++)
            {
                if (!combine.Contains(current[letter]))
                {
                    combine.Add(current[letter]);
                }
            }
        }

        combine.Sort();
        int[,] matrix = new int[combine.Count, combine.Count];
        for (int count = 0; count < messages.Length; count++)
        {
            string current = messages[count];
            for (int letter = 0; letter < current.Length - 1; letter++)
            {
                int first = combine.IndexOf(current[letter]);
                int second = combine.IndexOf(current[letter + 1]);
                matrix[first, second] = 1;
            }
        }

        Graph graph = new Graph(matrix);
        graph.TestDfs();
        List<int> order = graph.sortedElements;
        order.Reverse();
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < order.Count; i++)
        {
            result.Append(combine[order[i]]);
        }

        Console.WriteLine(result);
    }
}

public class Graph
{
    private int[,] edges;

    private int count;

    public bool[] visitedElements;

    public List<int> sortedElements = new List<int>();

    public Graph(int[,] e)
    {
        this.edges = e;
        this.count = e.GetLength(0);
        this.visitedElements = new bool[this.count];
    }

    public void Dfs(int startIndex)
    {
        visitedElements[startIndex] = true;

        for (int k = this.count - 1; k >= 0; k--)
        {
            if ((this.edges[startIndex, k] == 1) && (visitedElements[k] == false))
            {
                Dfs(k);
            }
        }

        sortedElements.Add(startIndex);
    }


    public void TestDfs()
    {
        for (int i = this.count - 1; i >= 0; i--)
        {
            if (this.visitedElements[i] == false)
            {
                Dfs(i);
            }
        }
    }

    public void ShowSort()
    {
        sortedElements.Reverse();

        for (int i = 0; i < sortedElements.Count; i++)
        {
            Console.Write("{0} ", sortedElements[i]);
        }
    }

}