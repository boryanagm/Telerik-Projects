using System;

namespace TopScores
{
	class Program
	{
		public static void Main()
		{
			int highestPossibleScore = 100;
			int[] unsortedScores = new int[] { 37, 89, 41, 65, 91, 53 };
			int[] sortedScores = SortScores(unsortedScores, highestPossibleScore);
			Console.WriteLine($"sortedScores: {string.Join(", ", sortedScores)}");
			// sortedScores: 91, 89, 65, 53, 41, 37
		}

		private static int[] SortScores(int[] unsortedScores, int highestPossibleScore)
		{
			// Array of 0s at indices 0 to highestPossibleScore
			int[] scoreCounts = new int[highestPossibleScore + 1];

			// Populate scoreCounts
			foreach (int score in unsortedScores)
			{
				scoreCounts[score]++;
			}

			// Populate the final sorted array
			int[] sortedScores = new int[unsortedScores.Length];
			int currentSortedIndex = 0;

			// For each item in scoreCounts starting from the biggest
			for (int score = highestPossibleScore; score >= 0; score--)
			{
				int count = scoreCounts[score];

				// For the number of times the item occurs
				for (int occurrence = 0; occurrence < count; occurrence++)
				{
					// Add it to the sorted array
					sortedScores[currentSortedIndex] = score;
					currentSortedIndex++;
				}
			}

			return sortedScores;
		}
	}
}
