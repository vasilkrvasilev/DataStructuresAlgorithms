using System;

public class Point
{
    public int Abscissa { get; set; }
    public int Ordinate { get; set; }

    public Point(int abscissa, int ordinate)
    {
        this.Abscissa = abscissa;
        this.Ordinate = ordinate;
    }

    public Point(string data)
    {
        string[] coordinates = data.Split(' ');
        if (coordinates.Length != 2)
        {
            throw new ArgumentException(
                "Invalid input! You should enter point  abscissa and ordinate separated by space.");
        }

        this.Abscissa = int.Parse(coordinates[0]);
        this.Ordinate = int.Parse(coordinates[1]);
    }
}