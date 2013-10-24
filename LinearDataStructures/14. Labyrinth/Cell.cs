using System;

public class Cell
{
    public const char EMPTY_CELL = '0';
    public const char WALL_CELL = 'X';
    public const char START_CELL = '*';
    public const char UNREACHED_CELL = 'U';

    private int row;
    private int column;
    private int value;
    private bool isVisited;
    private bool isStart;
    private bool isWall;

    /// <summary>
    /// Row of the cell
    /// </summary>
    /// <exception cref="ArgumentException">
    /// If try to set row to negative number</exception>
    public int Row
    {
        get { return this.row; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Invalid input! Row of the cell cannot be negative number.");
            }

            this.row = value;
        }
    }

    /// <summary>
    /// Column of the cell
    /// </summary>
    /// <exception cref="ArgumentException">
    /// If try to set column to negative number</exception>
    public int Column
    {
        get { return this.column; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Invalid input! Column of the cell cannot be negative number.");
            }

            this.column = value;
        }
    }

    /// <summary>
    /// Value of the cell
    /// </summary>
    /// <exception cref="ArgumentException">
    /// If try to set value to negative number</exception>
    public int Value
    {
        get { return this.value; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Invalid input! Value of the cell cannot be negative number.");
            }

            this.value = value;
        }
    }

    /// <summary>
    /// Is the cell visited or not
    /// </summary>
    public bool IsVisited
    {
        get { return this.isVisited; }
        set { this.isVisited = value; }
    }

    /// <summary>
    /// Is the cell wall cell or not
    /// </summary>
    public bool IsWall
    {
        get { return this.isWall; }
    }

    /// <summary>
    /// Is the cell start cell or not
    /// </summary>
    public bool IsStart
    {
        get { return this.isStart; }
    }

    /// <summary>
    /// Create cell
    /// </summary>
    /// <param name="symbol">Symbol of the cell</param>
    /// <param name="row">Row of the cell</param>
    /// <param name="column">Column of the cell</param>
    /// <remarks>Set value of IsVisited, IsWall and IsStart 
    /// according to the symbol of the cell</remarks>
    /// <exception cref="ArgumentException">
    /// If the symbol is not EMPTY_CELL, WALL_CELL, START_CELL</exception>
    public Cell(char symbol, int row, int column)
    {
        if (char.IsWhiteSpace(symbol))
        {
            throw new ArgumentException(
                "Invalid input! Symbol cannot be white space.");
        }

        this.Row = row;
        this.Column = column;
        this.Value = 0;

        if (symbol == EMPTY_CELL)
        {
            this.IsVisited = false;
            this.isWall = false;
            this.isStart = false;
        }
        else if (symbol == WALL_CELL)
        {
            this.IsVisited = true;
            this.isWall = true;
            this.isStart = false;
        }
        else if (symbol == START_CELL)
        {
            this.IsVisited = true;
            this.isWall = false;
            this.isStart = true;
        }
        else
        {
            throw new ArgumentException(string.Format(
                "Invalid input! Symbol should be '{0}', '{1}' or '{2}'.", EMPTY_CELL, WALL_CELL, START_CELL));
        }
    }
}