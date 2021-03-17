using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = rowsAndCols[0];
        int cols = rowsAndCols[1];

        bool[,] visited = new bool[rows, cols];

        string[,] field = PopulateMatrix(rows, cols);

        var print = new List<int>();

        for (int row = 0; row < rows; row++)
        {
            int result = 0;

            for (int col = 0; col < cols; col++)
            {
                result = FindLargestField(field, visited, row, col);

                if (result != 0)
                {
                    print.Add(result);
                }
            }
        }
        var printOrdered = print.OrderByDescending(x => x);

        Console.WriteLine(string.Join(Environment.NewLine, printOrdered));
    }
    static int FindLargestField(string[,] matrix, bool[,] visited, int row, int col)
    {
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return 0;
        }

        if (matrix[row, col] != "1")
        {
            return 0;
        }

        if (visited[row, col]) 
        {
            return 0;
        }

        visited[row, col] = true;

        return 1 + FindLargestField(matrix, visited, row - 1, col)
                 + FindLargestField(matrix, visited, row + 1, col)
                 + FindLargestField(matrix, visited, row, col - 1)
                 + FindLargestField(matrix, visited, row, col + 1);
    }

    static string[,] PopulateMatrix(int rows, int cols)
    {
        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string rowArr = Console.ReadLine();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowArr[col].ToString();
            }
        }

        return matrix;
    }
}
