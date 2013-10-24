using System;
using System.IO;
using System.Collections.Generic;

public class Traverse
{
    public static void Main()
    {
        // Search in given directory for given type of files (entered from the user)
        // Use recursive DFS and BFS
        Console.WriteLine("Enter directory with escaping");
        string path = Console.ReadLine();
        Console.WriteLine("Enter file extention");
        string extention = Console.ReadLine();
        TraverseDFS(path, extention);
        TraverseBFS(path, extention);
    }

    // Start the recursive DFS traversal if the directory
    public static void TraverseDFS(string path, string extention)
    {
        TraverseDFS(new DirectoryInfo(path), extention);
    }

    // Traverse input directory using recursive DFS and print all found files on the console
    private static void TraverseDFS(DirectoryInfo directory, string extention)
    {
        FileInfo[] files = directory.GetFiles();
        foreach (var file in files)
        {
            if (file.Extension == extention)
            {
                Console.WriteLine(file.Name);
            }
        }

        DirectoryInfo[] children = directory.GetDirectories();
        foreach (DirectoryInfo child in children)
        {
            TraverseDFS(child, extention);
        }
    }

    // Traverse the directory using BFS and print all found files on the console
    private static void TraverseBFS(string path, string extension)
    {
        Queue<DirectoryInfo> visited = new Queue<DirectoryInfo>();
        visited.Enqueue(new DirectoryInfo(path));
        while (visited.Count > 0)
        {
            DirectoryInfo directory = visited.Dequeue();
            FileInfo[] files = directory.GetFiles();
            foreach (var file in files)
            {
                if (file.Extension == extension)
                {
                    Console.WriteLine(file.Name);
                }
            }

            DirectoryInfo[] children = directory.GetDirectories();
            foreach (DirectoryInfo child in children)
            {
                visited.Enqueue(child);
            }
        }
    }
}