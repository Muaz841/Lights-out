using System;
using System.Collections.Generic;
using System.Text;

namespace Lights_out.Models;

public  class Board
{
    private readonly int[,] _cells;
    private readonly int _depth;

    public int Rows { get; }
    public int Cols { get; }

    public Board(int[,] cells, int depth)
    {
        _cells = cells;
        _depth = depth;
        Rows = cells.GetLength(0);
        Cols = cells.GetLength(1);
    }

    public bool IsSolved()
    {
        foreach (var value in _cells)
        {
            if (value != 0)
                return false;
        }
        return true;
    }

    public void Apply(Piece piece, int x, int y, int step)
    {
        for (int pr = 0; pr < piece.Rows; pr++)
        {
            for (int pc = 0; pc < piece.Cols; pc++)
            {
                if (piece.Cells[pr, pc])
                {
                    int row = y + pr;
                    int col = x + pc;
                    _cells[row, col] = (_cells[row, col] + step) % _depth;
                }
            }
        }
    }
}