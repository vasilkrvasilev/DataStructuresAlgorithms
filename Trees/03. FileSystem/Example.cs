using System;
using System.Collections.Generic;
using System.IO;

public class Example
{
    public static void Main()
    {
        // Create folder reflecting the structure of chosen by the user directory and count its size
        Console.WriteLine("Enter directory with escaping");
        string path = Console.ReadLine();
        Folder fileTree = TraverseDFS(path);
        double totalSize = fileTree.CountSize();
    }

    // Start the recursive DFS traversal if the directory (creation of folder reflecting its structure)
    public static Folder TraverseDFS(string path)
    {
        Folder fileTree = new Folder(path);
        TraverseDFS(new DirectoryInfo(path), fileTree);
        return fileTree;
    }

    // Traverse input directory using recursive DFS and reflect its structure in input folder
    private static void TraverseDFS(DirectoryInfo directory, Folder currentFolder)
    {
        FileInfo[] files = directory.GetFiles();
        List<File> fileList = new List<File>();
        foreach (var file in files)
        {
            fileList.Add(new File(file.Name, file.Length));
        }

        currentFolder.AddFiles(fileList);

        DirectoryInfo[] children = directory.GetDirectories();
        List<Folder> folderList = new List<Folder>();
        foreach (DirectoryInfo child in children)
        {
            Folder childFolder = new Folder(child.Name);
            currentFolder.AddFolder(childFolder);
            TraverseDFS(child, childFolder);
        }
    }
}