using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cable
{
    static void Main()
    {
        // Read the input
        Console.WriteLine("Enter number of houses");
        int houses = int.Parse(Console.ReadLine());
        List<Edge> paths = ReadPaths();
        bool[] used = new bool[houses + 1];

        // Add to priority queue all paths starting form paths[0].StartNode
        PriorityQueue<Edge> priority = new PriorityQueue<Edge>();
        for (int count = 0; count < paths.Count; count++)
        {
            if (paths[count].StartNode == paths[0].StartNode)
            {
                priority.Enqueue(paths[count]);
            }
        }

        // Find minimum spanning tree
        used[paths[0].StartNode] = true;
        List<Edge> minimumSpanningTree = new List<Edge>();
        FindMinimumSpanningTree(used, priority, minimumSpanningTree, paths);
        PrintMinimumSpanningTree(minimumSpanningTree);
    }

    private static List<Edge> ReadPaths()
    {
        Console.WriteLine("enter number of possible paths");
        int numberPaths = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter paths between houses - first, second and distance, separated by space");
        List<Edge> paths = new List<Edge>();
        for (int count = 0; count < numberPaths; count++)
        {
            string input = Console.ReadLine();
            string[] inputData = input.Split(' ');
            Edge currentPath =
                new Edge(int.Parse(inputData[0]), int.Parse(inputData[1]), int.Parse(inputData[2]));
            paths.Add(currentPath);
        }

        return paths;
    }

    private static void FindMinimumSpanningTree(bool[] used,
        PriorityQueue<Edge> priority, List<Edge> minimumSpanningTree, List<Edge> paths)
    {
        while (priority.Count > 0)
        {
            // Get the shortest path
            // Chack if it cause cycle
            // If not added to minimum spanning tree and 
            // Add paths starting from its end to priority queue
            Edge currentPath = priority.Dequeue();
            if (!used[currentPath.EndNode])
            {
                used[currentPath.EndNode] = true;
                minimumSpanningTree.Add(currentPath);
                AddEdges(currentPath, paths, minimumSpanningTree, priority, used);
            }
        }
    }

    private static void AddEdges(Edge currentPath,
        List<Edge> paths, List<Edge> minimumSpanningTree, PriorityQueue<Edge> priority, bool[] used)
    {
        // Add the path if it is not already added to minimum spanning tree, 
        // Starts from currentPath.EndNode and does not cause cycle
        for (int count = 0; count < paths.Count; count++)
        {
            if (!minimumSpanningTree.Contains(paths[count]))
            {
                if (currentPath.EndNode == paths[count].StartNode && !used[paths[count].EndNode])
                {
                    priority.Enqueue(paths[count]);
                }
            }
        }
    }

    private static void PrintMinimumSpanningTree(List<Edge> minimumSpanningTree)
    {
        for (int count = 0; count < minimumSpanningTree.Count; count++)
        {
            Console.WriteLine("{0}", minimumSpanningTree[count]);
        }
    }
}