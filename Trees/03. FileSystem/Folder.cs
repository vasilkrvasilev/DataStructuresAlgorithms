using System;
using System.Collections.Generic;

public class Folder
{
    private string name;
    private List<File> files;
    private List<Folder> folders;

    public Folder(string name)
    {
        this.Name = name;
        this.files = new List<File>();
        this.folders = new List<Folder>();
    }

    /// <summary>
    /// Name of the folder
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If the name of the folder is null or white space</exception>
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(
                    "Invalid input! The file name cannot be null ot white space.");
            }

            this.name = value;
        }
    }

    /// <summary>
    /// Add collection (List) of files to the folder
    /// </summary>
    /// <param name="files">Collection (List) of files to add</param>
    /// <exception cref="ArgumentNullException">
    /// If try to add null collection</exception>
    public void AddFiles(List<File> files)
    {
        if (files == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Cannot add empty list of files.");
        }

        this.files.AddRange(files);
    }

    /// <summary>
    /// Add child folder to the folder
    /// </summary>
    /// <param name="folder">Child folder to add</param>
    /// <exception cref="ArgumentNullException">
    /// If try to add child folder equal to null</exception>
    public void AddFolder(Folder folder)
    {
        if (folder == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Cannot add empty folder.");
        }

        this.folders.Add(folder);
    }

    /// <summary>
    /// Count the total size of all files in the folder
    /// including files of all its descendant folders
    /// </summary>
    /// <remarks>Start recursive DFS</remarks>
    /// <returns>Total size of all files in the folder</returns>
    public double CountSize()
    {
        double totalSize = 0;
        totalSize = this.CountSize(totalSize);
        return totalSize;
    }

    /// <summary>
    /// Count the total size of all files in current folder
    /// </summary>
    /// <param name="currentSize">Current size of all traversed
    /// files in the folder before current folder</param>
    /// <remarks>Use recursive DFS</remarks>
    /// <returns>Total size of all traversed
    /// files in the folder after current folder</returns>
    private double CountSize(double currentSize)
    {
        foreach (var file in this.files)
        {
            currentSize += file.Size;
        }

        foreach (var folder in this.folders)
        {
            currentSize = folder.CountSize(currentSize);
        }

        return currentSize;
    }
}