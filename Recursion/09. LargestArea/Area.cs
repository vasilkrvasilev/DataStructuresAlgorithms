using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Area
{
    public Area(int size, int row, int column)
    {
        this.Size = size;
        this.Row = row;
        this.Column = column;
    }

    public int Size { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
}