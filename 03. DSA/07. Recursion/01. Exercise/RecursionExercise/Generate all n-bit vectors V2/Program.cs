using System;

class Program
{
    static void Main()
    {
        int n = 3;

        int[] vector = new int[n];

        GenerateOneZeroVector(vector, 0);
    }

    public static void GenerateOneZeroVector(int[] vector, int currentIndex)
    {
        if (currentIndex == vector.Length)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i]);
            }
            Console.WriteLine();

            return;
        }

        vector[currentIndex] = 0;
        GenerateOneZeroVector(vector, currentIndex + 1);

        vector[currentIndex] = 1;
        GenerateOneZeroVector(vector, currentIndex + 1);
    }
}
