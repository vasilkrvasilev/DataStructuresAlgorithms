using System;
using System.Collections.Generic;

public class LabyrinthDemo
{
    public static void Main()
    {
        //Create a labyrinth (matrix of cells)
        Console.WriteLine("Enter labyrinth size");
        int size = int.Parse(Console.ReadLine());
        Cell[,] cellLabyrinth = new Cell[size, size];
        Cell startCell = new Cell(Cell.START_CELL, 0, 0);
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                char symbol = char.Parse(Console.ReadLine());
                cellLabyrinth[row, column] = new Cell(symbol, row, column);
                if (symbol == Cell.START_CELL)
                {
                    startCell.Row = row;
                    startCell.Column = column;
                }
            }
        }

        // Traverse and print the result labyrinth
        TraverseLabyrinthBFS(size, cellLabyrinth, startCell);
        //TraverseLabyrinthDFS(size, cellLabyrinth, startCell);

        PrintLabyrinth(size, cellLabyrinth);
    }

    private static void TraverseLabyrinthBFS(int size, Cell[,] cellLabyrinth, Cell startCell)
    {
        // Add the start cell
        Queue<Cell> queue = new Queue<Cell>();
        queue.Enqueue(startCell);

        // Add the neighbour cells by HandleCellBFS() method
        while (queue.Count > 0)
        {
            Cell currentElement = queue.Dequeue();
            int count = currentElement.Value + 1;
            if (currentElement.Column > 0)
            {
                Cell left = cellLabyrinth[currentElement.Row, currentElement.Column - 1];
                HandleCellBFS(queue, count, left);
            }

            if (currentElement.Column < size - 1)
            {
                Cell right = cellLabyrinth[currentElement.Row, currentElement.Column + 1];
                HandleCellBFS(queue, count, right);
            }

            if (currentElement.Row > 0)
            {
                Cell up = cellLabyrinth[currentElement.Row - 1, currentElement.Column];
                HandleCellBFS(queue, count, up);
            }

            if (currentElement.Row < size - 1)
            {
                Cell down = cellLabyrinth[currentElement.Row + 1, currentElement.Column];
                HandleCellBFS(queue, count, down);
            }
        }
    }

    private static void HandleCellBFS(Queue<Cell> queue, int count, Cell cell)
    {
        if (!cell.IsVisited)
        {
            cell.IsVisited = true;
            cell.Value = count;
            queue.Enqueue(cell);
        }
    }

    private static void TraverseLabyrinthDFS(int size, Cell[,] cellLabyrinth, Cell startCell)
    {
        // Add the start cell
        Stack<Cell> stack = new Stack<Cell>();
        stack.Push(startCell);

        // Add the neighbour cells by HandleCellDFS() method
        while (stack.Count > 0)
        {
            Cell currentElement = stack.Pop();
            int count = currentElement.Value + 1;
            if (currentElement.Column > 0)
            {
                Cell left = cellLabyrinth[currentElement.Row, currentElement.Column - 1];
                HandleCellDFS(stack, count, left);
            }

            if (currentElement.Column < size - 1)
            {
                Cell right = cellLabyrinth[currentElement.Row, currentElement.Column + 1];
                HandleCellDFS(stack, count, right);
            }

            if (currentElement.Row > 0)
            {
                Cell up = cellLabyrinth[currentElement.Row - 1, currentElement.Column];
                HandleCellDFS(stack, count, up);
            }

            if (currentElement.Row < size - 1)
            {
                Cell down = cellLabyrinth[currentElement.Row + 1, currentElement.Column];
                HandleCellDFS(stack, count, down);
            }
        }
    }

    private static void HandleCellDFS(Stack<Cell> stack, int count, Cell cell)
    {
        if (!cell.IsVisited)
        {
            cell.IsVisited = true;
            cell.Value = count;
            stack.Push(cell);
        }
    }

    private static void PrintLabyrinth(int size, Cell[,] cellLabyrinth)
    {
        // Print the result labyrinth
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                Cell currentCell = cellLabyrinth[row, column];
                char symbol;

                if (currentCell.IsVisited)
                {
                    if (currentCell.IsStart)
                    {
                        symbol = Cell.START_CELL;
                    }
                    else if (currentCell.IsWall)
                    {
                        symbol = Cell.WALL_CELL;
                    }
                    else
                    {
                        symbol = char.Parse(currentCell.Value.ToString());
                    }
                }
                else
                {
                    symbol = Cell.UNREACHED_CELL;
                }

                Console.Write("{0} ", symbol.ToString());
            }

            Console.WriteLine();
        }
    }
}