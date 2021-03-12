using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = rowsAndCols[0];
        int cols = rowsAndCols[1];

        int[,] field = PopulateMatrix(rows, cols);

        int[] startCellIndexes = FindStartCell(field);
        int startingRow = startCellIndexes[0];
        int startingCol = startCellIndexes[1];

        Console.WriteLine(CollectedCoins(field, startingRow, startingCol, field[startingRow, startingCol]));
    }

    static int CollectedCoins(int[,] matrix, int row, int col, int current)
    {
        if (IsSurroundedByEmptyCells(matrix, row, col)) 
        {
            return 0; 
        }

        // Find the biggest num
        // If equal, prioritizе left - right - up - down
        int currRow = FindMostExpensiveCell(matrix, row, col)[0];
        int currCol = FindMostExpensiveCell(matrix, row, col)[1];
        row = currRow;
        col = currCol;
        current = matrix[currRow, currCol];
        matrix[currRow, currCol] -= 1;
        current -= 1;

        return 1 + CollectedCoins(matrix, row, col, current); 
    }

    static int[] FindMostExpensiveCell(int[,] matrix, int row, int col)
    {
        int maxNum = 1;
        int[] coordinates = new int[2];

        if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] >= maxNum) // check bottom
        {
            maxNum = matrix[row + 1, col];
            coordinates[0] = row + 1;
            coordinates[1] = col;
        }
       
        if (row - 1 >= 0 && matrix[row - 1, col] >= maxNum) // check up
        {
            maxNum = matrix[row - 1, col];
            coordinates[0] = row - 1;
            coordinates[1] = col;
        }
        if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] >= maxNum) // check right
        {
            maxNum = matrix[row, col + 1];
            coordinates[0] = row;
            coordinates[1] = col + 1;
        }
        if (col - 1 >= 0 && matrix[row, col - 1] >= maxNum) // check left
        {
            maxNum = matrix[row, col - 1];
            coordinates[0] = row;
            coordinates[1] = col - 1;
        }

        return coordinates;
    }
    static bool IsSurroundedByEmptyCells(int[,] matrix, int row, int col) 
    {
        bool isLeftBorder = false;
        bool isRightBorder = false;
        bool isTopBorder = false;
        bool isBottomBorder = false;

        if (row == 0)
        {
            isTopBorder = true;
        }
        if (row == matrix.GetLength(0) - 1)
        {
            isBottomBorder = true;
        }
        if (col == 0)
        {
            isLeftBorder = true;
        }
        if (col == matrix.GetLength(1) - 1)
        {
            isRightBorder = true;
        }


        if (isLeftBorder && isTopBorder && isRightBorder == false && isBottomBorder == false
            && matrix[row + 1, col] == 0 && matrix[row, col + 1] == 0)
        {
            return true;
        }
        else if (isLeftBorder && isBottomBorder && isRightBorder == false && isTopBorder == false
            && matrix[row - 1, col] == 0 && matrix[row, col + 1] == 0)
        {
            return true;
        }
        else if (isLeftBorder && isRightBorder == false && isTopBorder == false && isBottomBorder == false
            && matrix[row - 1, col] == 0 && matrix[row, col + 1] == 0 && matrix[row + 1, col] == 0)
        {
            return true;
        }
        else if (isLeftBorder == false && isRightBorder == false && isTopBorder && isBottomBorder == false
            && matrix[row, col - 1] == 0 && matrix[row + 1, col] == 0 && matrix[row, col + 1] == 0)
        {
            return true;
        }
        else if (isLeftBorder == false && isRightBorder && isTopBorder && isBottomBorder == false
            && matrix[row, col - 1] == 0 && matrix[row + 1, col] == 0)
        {
            return true;
        }
        else if (isLeftBorder == false && isRightBorder && isTopBorder == false && isBottomBorder == false
            && matrix[row - 1, col] == 0 && matrix[row, col - 1] == 0 && matrix[row + 1, col] == 0)
        {
            return true;
        }
        else if (isLeftBorder == false && isRightBorder && isTopBorder == false && isBottomBorder
            && matrix[row, col - 1] == 0 && matrix[row - 1, col] == 0)
        {
            return true;
        }
        else if (isLeftBorder == false && isRightBorder == false && isTopBorder == false && isBottomBorder
            && matrix[row, col - 1] == 0 && matrix[row - 1, col] == 0 && matrix[row, col + 1] == 0)
        {
            return true;
        }
        else if (isLeftBorder == false && isRightBorder == false && isTopBorder == false && isBottomBorder == false
            && matrix[row, col - 1] == 0 && matrix[row, col + 1] == 0 && matrix[row - 1, col] == 0 && matrix[row + 1, col] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static int[,] PopulateMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string[] rowArr = Console.ReadLine().Split(' ');

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(rowArr[col]);
            }
        }

        return matrix;
    }

    static int[] FindStartCell(int[,] matrix)
    {
        int[] cellIndexes = new int[2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 0)
                {
                    cellIndexes[0] = row;
                    cellIndexes[1] = col;

                    return cellIndexes;
                }
            }
        }

        return cellIndexes;
    }
}
