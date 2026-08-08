using System;
using System.Collections.Generic;
using System.Text;

namespace Lights_out.Models;

public class Piece
{
    public bool[,] Cells { get; }
    public int Rows { get; }
    public int Cols { get; }

    public Piece(bool[,] cells)
    {
        Cells = cells;
        Rows = cells.GetLength(0);
        Cols = cells.GetLength(1);
    }
}