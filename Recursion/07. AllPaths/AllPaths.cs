using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AllPaths
{
    static char[,] matrix;
    static int startRow = -1;
    static int startColumn = -1;
    static bool isExit = false;
    static List<char> path = new List<char>();

    public static void Main()
    {
        InitializeMatrix();
        if (startRow == -1 || !isExit)
        {
            throw new InvalidOperationException(
                "Invalid oparation! You did not enter start or exit point.");
        }

        // Start recursion
        FindPath(startRow, startColumn, 'S');

    }

    private static void FindPath(int row, int column, char direction)
    {
        // Bottoms of recursion
        if (row < 0 || column < 0 || row >= matrix.GetLength(0) || column > matrix.GetLength(1))
        {
            return;
        }

        if (matrix[row, column] == 'w' || matrix[row, column] == 'v')
        {
            return;
        }

        if (matrix[row, column] == 'e')
        {
            path.Add(direction);
            PrintPath();
            path.RemoveAt(path.Count - 1);
            return;
        }

        // Process next elements
        matrix[row, column] = 'v';
        path.Add(direction);
        FindPath(row + 1, column, 'D');
        FindPath(row - 1, column, 'U');
        FindPath(row, column + 1, 'R');
        FindPath(row, column - 1, 'L');
        matrix[row, column] = ' ';
        path.RemoveAt(path.Count - 1);
    }

    private static void PrintPath()
    {
        for (int count = 1; count < path.Count; count++)
        {
            Console.Write(path[count]);
        }

        Console.WriteLine();
    }

    private static void InitializeMatrix()
    {
        Console.WriteLine("Enter number of rows");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of columns");
        int columns = int.Parse(Console.ReadLine());
        matrix = new char[rows, columns];
        Console.WriteLine("Enter cell symbol: \'s\' - start, \' \' - empty, \'w\' - wall, \'e\' - exit");
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                char symbol = char.Parse(Console.ReadLine());
                matrix[row, column] = symbol;
                if (symbol == 's')
                {
                    startRow = row;
                    startColumn = column;
                }

                if (symbol == 'e')
                {
                    isExit = true;
                }
            }
        }
    }
}