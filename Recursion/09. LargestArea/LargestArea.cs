using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LargestArea
{
    static char[,] matrix;
    static int startRow = -1;
    static int startColumn = -1;
    static int area = 0;
    static Area maxArea = new Area(0, -1, -1);

    public static void Main()
    {
        InitializeMatrix();
        FindEmptyCell();

        // Search areas by finding one empty cell of them and calculate their size by recursion
        while (startRow != -1)
        {
            int currentStartRow = startRow;
            int currentStartColumn = startColumn;

            // Start recursion
            FindPath(startRow, startColumn);
            if (area > maxArea.Size)
            {
                maxArea = new Area(area, currentStartRow, currentStartColumn);
            }

            area = 0;
            startRow = -1;
            startColumn = -1;
            FindEmptyCell();
        }

        if (maxArea.Size == 0)
        {
            Console.WriteLine("There are no empty cells in the matrix");
        }
        else
        {
            Console.WriteLine("Largest area of empty cells has size {0} and start at [{1}, {2}]",
                maxArea.Size, maxArea.Row, maxArea.Column);
        }

    }

    private static void FindEmptyCell()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                if (matrix[row, column] == ' ')
                {
                    startRow = row;
                    startColumn = column;
                    return;
                }
            }
        }
    }

    private static void FindPath(int row, int column)
    {
        // Bottoms of recursion
        if (row < 0 || column < 0 || row >= matrix.GetLength(0) || column >= matrix.GetLength(1))
        {
            return;
        }

        if (matrix[row, column] == 'w' || matrix[row, column] == 'v')
        {
            return;
        }

        // Process next elements
        matrix[row, column] = 'v';
        area++;
        FindPath(row + 1, column);
        FindPath(row - 1, column);
        FindPath(row, column + 1);
        FindPath(row, column - 1);
    }

    private static void InitializeMatrix()
    {
        Console.WriteLine("Enter number of rows");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of columns");
        int columns = int.Parse(Console.ReadLine());
        matrix = new char[rows, columns];
        Console.WriteLine("Enter cell symbol: \'w\' - wall, \' \' - empty");
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                char symbol = char.Parse(Console.ReadLine());
                matrix[row, column] = symbol;
            }
        }
    }
}