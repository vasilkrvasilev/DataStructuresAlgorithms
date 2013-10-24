using System;

public class Triangle
{
    static void Main()
    {
        // Read the input
        Console.WriteLine("Enter triangle points' abscissa and ordinate separated by space");
        string firstPoint = Console.ReadLine();
        Point first = new Point(firstPoint);
        string secondPoint = Console.ReadLine();
        Point second = new Point(secondPoint);
        string thirdPoint = Console.ReadLine();
        Point third = new Point(thirdPoint);
        Console.WriteLine("Enter point abscissa and ordinate separated by space");
        string currentPoint = Console.ReadLine();
        Point current = new Point(currentPoint);

        // Calculate triangles areas
        double triangleArea = CalculateArea(first, second, third);
        double firstArea = CalculateArea(first, second, current);
        double secondArea = CalculateArea(first, current, third);
        double thirdArea = CalculateArea(current, second, third);

        // Check is the point inner or outer
        if (Math.Round(triangleArea, 3) == Math.Round(firstArea + secondArea + thirdArea, 3))
        {
            Console.WriteLine("Current point is inner for the triange");
        }
        else
        {
            Console.WriteLine("Current point is outer for the triange");
        }
    }

    private static double CalculateArea(Point first, Point second, Point third)
    {
        // Calculate length of triangle sides
        double firstSide = CalculateLength(first, second);
        double secondSide = CalculateLength(first, third);
        double thirdSide = CalculateLength(second, third);

        // Calculate triangle area
        double semiparameter = (firstSide + secondSide + thirdSide) / 2;
        double area = Math.Sqrt(semiparameter * (semiparameter - firstSide) *
            (semiparameter - secondSide) * (semiparameter - thirdSide));

        return area;
    }

    private static double CalculateLength(Point first, Point second)
    {
        // Calculate distance between two points
        double xDistance = Math.Abs(first.Abscissa - second.Abscissa);
        double yDistance = Math.Abs(first.Ordinate - second.Ordinate);
        double length = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);

        return length;
    }
}