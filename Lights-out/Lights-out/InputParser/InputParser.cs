using Lights_out.Models;

namespace Lights_out.InputParser
{
    public  class InputParser
    {
        public static(Board board, List<Piece> pieces) Parse(string[] lines)
        {
            int depth = int.Parse(lines[0].Trim());
            Board board = ParseBoard(lines[1].Trim(), depth);
            List<Piece> pieces = ParsePieces(lines[2].Trim());

            return (board, pieces);
        }

        private static Board ParseBoard(string line, int depth)
        {
            string[] rows = line.Split(',');
            int[,] cells = new int[rows.Length, rows[0].Length];

            for (int r = 0; r < rows.Length; r++)
                for (int c = 0; c < rows[r].Length; c++)
                    cells[r, c] = rows[r][c] - '0';

            return new Board(cells, depth);
        }

        private static List<Piece> ParsePieces(string line)
        {
            string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<Piece> pieces = new();

            foreach (string token in tokens)
            {
                string[] rows = token.Split(',');

                bool[,] cells = new bool[rows.Length, rows[0].Length];

                for (int r = 0; r < rows.Length; r++)
                    for (int c = 0; c < rows[r].Length; c++) cells[r, c] = rows[r][c] == 'X';

                pieces.Add(new Piece(cells));
            }

            return pieces;
        }
    }
}
