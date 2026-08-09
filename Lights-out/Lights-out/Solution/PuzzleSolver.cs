using Lights_out.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lights_out.Solution
{
    public class PuzzleSolver
    {
        private readonly Board _board;
        private readonly List<Piece> _pieces;
        private readonly int _depth;
        private readonly List<(int X, int Y)> _result = new();

        public PuzzleSolver(Board board, List<Piece> pieces, int depth)
        {
            _board = board;
            _pieces = pieces;
            _depth = depth;
        }


        public List<(int X, int Y)>? Solve()
        {
            return Place(0) ? _result : null;
        }

        private bool Place(int index)
        {
            if (index == _pieces.Count)
                return _board.IsSolved();

            Piece piece = _pieces[index];
            int maxX = _board.Cols - piece.Cols;
            int maxY = _board.Rows - piece.Rows;

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    _board.Apply(piece, x, y, 1);        
                    _result.Add((x, y));

                    if (Place(index + 1))               
                        return true;

                    _result.RemoveAt(_result.Count - 1);
                    _board.Apply(piece, x, y, _depth - 1); 
                }
            }

            return false;
        }
    }
    
}
