using System;

static class LevenshteinDistance
{
    public static double Compute(string firstWord, string secondWord, 
        double replace, double delete, double insert)
    {
        int firstLetters = firstWord.Length;
        int secondLetters = secondWord.Length;
        double[,] solution = new double[firstLetters + 1, secondLetters + 1];

        // Check if one of the words is empty
        if (firstLetters == 0)
        {
            return secondLetters;
        }

        if (secondLetters == 0)
        {
            return firstLetters;
        }

        // Fill first row and first column of the matrix solution
        for (int count = 0; count <= firstLetters; count++)
        {
            solution[count, 0] = count;
        }

        for (int count = 0; count <= secondLetters; count++)
        {
            solution[0, count] = count;
        }

        // Iterate through each combination of letters
        for (int countFirst = 1; countFirst <= firstLetters; countFirst++)
        {
            for (int countSecond = 1; countSecond <= secondLetters; countSecond++)
            {
                // Calculate the cost to replace, delete or insert a letter
                double cost = 0;
                if (secondWord[countSecond - 1] != firstWord[countFirst - 1])
                {
                    cost = replace;
                }

                double costCopyOrReplace = solution[countFirst - 1, countSecond - 1] + cost;
                double costToInsert = solution[countFirst - 1, countSecond] + insert;
                double costToDelete = solution[countFirst, countSecond - 1] + delete;

                // Save the min cost
                solution[countFirst, countSecond] = Math.Min(
                    Math.Min(costToInsert, costToDelete), costCopyOrReplace);
            }
        }

        // Return solution which is in the last cell of the matrix solution
        return solution[firstLetters, secondLetters];
    }
}