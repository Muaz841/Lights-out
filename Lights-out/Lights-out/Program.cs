using Lights_out.InputParser;
using Lights_out.Solution;

string path = args.Length > 0 ? args[0] : "01.txt";
string[] lines = File.ReadAllLines(path);

var (board, pieces) = InputParser.Parse(lines);

int depth = int.Parse(lines[0].Trim());
var solver = new PuzzleSolver(board, pieces, depth);

var solution = solver.Solve();

if (solution != null)
    Console.WriteLine(string.Join(" ", solution.Select(p => $"{p.X},{p.Y}")));
else
    Console.WriteLine("No solution found");