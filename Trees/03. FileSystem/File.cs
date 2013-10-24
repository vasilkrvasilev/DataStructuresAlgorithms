using System;

public class File
{
    private string name;
    private double size;

    public File(string name, double size)
    {
        this.Name = name;
        this.Size = size;
    }

    /// <summary>
    /// Name of the file
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If the name of the file is null or white space</exception>
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
    /// Size of the file
    /// </summary>
    /// <exception cref="ArgumentException">
    /// If the size of the file is negative number</exception>
    public double Size
    {
        get { return this.size; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Invalid input! The file size cannot be negative number.");
            }

            this.size = value;
        }
    }
}