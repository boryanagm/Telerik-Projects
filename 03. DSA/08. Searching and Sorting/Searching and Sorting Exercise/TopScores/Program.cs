using System;

class Program
{
    static void Main()
    {
        int highestPossibleScore = 100;
        int[] unsortedScores = new int[] { 37, 89, 41, 65, 91, 53 };

        int[] sortedScores = SortedScores(unsortedScores, highestPossibleScore);

        Console.WriteLine(string.Join(", ", sortedScores));
    }

    static int[] SortedScores(int[] unsortedScores, int highestPossibleScores)
    {
        int[] scoreCounts = new int[highestPossibleScores + 1];

        foreach (int score in unsortedScores)
        {
            scoreCounts[score]++;
        }

        int[] sortedScores = new int[unsortedScores.Length];

        int currentSortedIndex = 0;

        for (int i = highestPossibleScores; i >= 0; i--)
        {
            int count = scoreCounts[i];

            for (int j = 0; j < count; j++)
            {
                sortedScores[currentSortedIndex] = i;
                currentSortedIndex++;
            }
        }

        return sortedScores;
    }
}
