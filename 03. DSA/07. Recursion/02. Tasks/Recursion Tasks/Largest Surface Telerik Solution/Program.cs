using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //read input
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];
        bool[,] visited = new bool[rows, cols];
        int maxResult = 0;

        //generate matrix
        int[,] matrix = GenerateMatrix(rows, cols);

        //solve
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                maxResult = Math.Max(maxResult, Solve(matrix, visited, r, c, matrix[r, c]));
            }
        }

        Console.WriteLine(maxResult);
    }

    // 1 3 2 2 2 4
    // 3 3 3 2 4 4
    // 4 3 1 2 3 3
    // 4 3 1 3 3 1
    // 4 3 3 3 1 1

    static int Solve(int[,] matrix, bool[,] visited, int row, int col, int current)
    {
        //check if we are inside the matrix
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            return 0;

        //check if new value is same as current
        if (matrix[row, col] != current)
            return 0;

        //check if cell is visited
        if (visited[row, col])
            return 0;

        visited[row, col] = true;

        return 1 + Solve(matrix, visited, row - 1, col, current)  // UP
                 + Solve(matrix, visited, row + 1, col, current)  // DOWN
                 + Solve(matrix, visited, row, col - 1, current)  //LEFT
                 + Solve(matrix, visited, row, col + 1, current); //RIGHT
    }

    static int[,] GenerateMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            string[] row = Console.ReadLine().Split(' ');
            for (int c = 0; c < cols; c++)
            {
                matrix[r, c] = int.Parse(row[c]);
            }
        }

        return matrix;
    }
}
