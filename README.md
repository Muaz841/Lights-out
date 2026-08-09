Lights Out Solver

A console application that solves a generalized "Lights Out" puzzle. Given a board of numbered cells and a set of pieces, it finds where to place each piece so that every cell ends at 0.
The puzzle
Each cell holds a value that cycles 0 -> 1 -> ... -> depth-1 -> 0.
Placing a piece increments (mod depth) every board cell that lines up with an X in the piece.
Every piece must be placed exactly once and must fit fully on the board.
Goal: after all pieces are placed, every cell is 0.
Input format

A text file with 3 lines:

Depth (2, 3, or 4).
Board rows separated by commas; each digit is a cell's starting value.
Pieces separated by spaces; each piece's rows separated by commas, where X = increment and . = no effect.

Example (sample-input.txt):

2
001,011,011
.X,XX XX .X,.X,XX
Output

The placement coordinate of each piece, in input order, space-separated. Each coordinate is x,y (column,row) of the piece's top-left corner, with the board's top-left being 0,0.

Example output:

0,1 0,2 1,0

If no arrangement solves the board, it prints No solution found.

How to run
dotnet run --project Lights-out -- sample-input.txt

Or set the input file name as the command-line argument in the debug launch profile and run from Visual Studio.

Approach

Depth-first backtracking search (PuzzleSolver):

For the current piece, try every position where it fits fully on the board.
Apply it to the board (each X cell +1 mod depth) and record the position.
Recurse to the next piece.
If all pieces are placed and the board is all zeros, return that solution.
Otherwise undo the placement (reverse the board change and drop the recorded position) and try the next position.

Only the first valid solution found is returned, which satisfies the spec's "one solution is required even if multiple exist".

Project structure
Lights-out/
  Models/
    Board.cs          board grid, apply piece, solved check
    Piece.cs          piece shape (bool grid)
  Parsing/
    InputParser.cs    parses the 3-line input into a board + pieces
  Solving/
    PuzzleSolver.cs   backtracking search
  Program.cs          entry point: read file, parse, solve, print
Assumptions and notes
Input is assumed well-formed (depth is 2/3/4; each board and piece row has a consistent width). Adding stricter validation for malformed pieces is a natural extension.
If a piece is larger than the board it cannot be placed, and the solver reports no solution.
Pieces are not rotated, and the board is not rotated, per the spec.
