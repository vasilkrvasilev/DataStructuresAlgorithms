using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EightQueens
{
    static int[,] matrix = new int[8, 8];
    static List<Cell> solution = new List<Cell>();
    //static int numberSolutions = 0;

    public static void Main()
    {
        // Start recursion for 8 possible positions of the first queen
        for (int index = 0; index < 8; index++)
        {
            MarkAllAttackedPositions(0, index, 0, index);
            PutQueens(2, 0);
            UnmarkAllAttackedPositions(0, index, 0, index);
        }
    }

    static void PutQueens(int count, int lastRow)
    {
        // Bottom of recursion
        if (count > 8)
        {
            //numberSolutions++;
            PrintSolution();
        }
        else
        {
            for (int row = lastRow + 1; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    // Process next queen
                    if (matrix[row, column] == 0)
                    {
                        MarkAllAttackedPositions(row, column, row, column);
                        PutQueens(count + 1, row);
                        UnmarkAllAttackedPositions(row, column, row, column);
                    }
                }
            }
        }
    }

    private static void MarkAllAttackedPositions(int row, int column, int currentRow, int currentColumn)
    {
        // Add cell to solution
        solution.Add(new Cell(row, column));

        // Mark vertical cells
        for (currentRow = 0; currentRow < 8; currentRow++)
        {
            matrix[currentRow, column]++;
        }

        // Mark horizontal cells
        for (currentColumn = 0; currentColumn < 8; currentColumn++)
        {
            matrix[row, currentColumn]++;
        }

        // Mark diagonal cells
        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]++;
            currentRow--;
            currentColumn--;
        }

        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]++;
            currentRow--;
            currentColumn++;
        }

        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]++;
            currentRow++;
            currentColumn--;
        }

        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]++;
            currentRow++;
            currentColumn++;
        }
    }

    private static void UnmarkAllAttackedPositions(int row, int column, int currentRow, int currentColumn)
    {
        // Remove cell from solution
        solution.RemoveAt(solution.Count - 1);

        // Unmark vertical cells
        for (currentRow = 0; currentRow < 8; currentRow++)
        {
            matrix[currentRow, column]--;
        }

        // Unmark horizontal cells
        for (currentColumn = 0; currentColumn < 8; currentColumn++)
        {
            matrix[row, currentColumn]--;
        }

        // Unmark diagonal cells
        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]--;
            currentRow--;
            currentColumn--;
        }

        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]--;
            currentRow--;
            currentColumn++;
        }

        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]--;
            currentRow++;
            currentColumn--;
        }

        currentRow = row;
        currentColumn = column;
        while (currentRow >= 0 && currentRow < 8 && currentColumn >= 0 && currentColumn < 8)
        {
            matrix[currentRow, currentColumn]--;
            currentRow++;
            currentColumn++;
        }
    }

    private static void PrintSolution()
    {
        Console.WriteLine("Solution:");
        foreach (var item in solution)
        {
            Console.Write("[{0}, {1}] ", item.Row, item.Column);
        }

        Console.WriteLine();
    }
}