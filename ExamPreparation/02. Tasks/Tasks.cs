using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tasks
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] pleasantnessData = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pleasantness = pleasantnessData.Select(x => int.Parse(x)).ToArray();
        int variety = int.Parse(Console.ReadLine());
        int solution = SolveTasks(pleasantness, variety);
        Console.WriteLine(solution);
    }

    private static int SolveTasks(int[] pleasantness, int variety)
    {
        int solution = pleasantness.Length;
        for (int i = 0; i < pleasantness.Length; i++)
        {
            for (int j = i + 1; j < pleasantness.Length; j++)
            {
                int difference = Math.Abs(pleasantness[i] - pleasantness[j]);
                if (difference < variety)
                {
                    continue;
                }
                int tasksToI = (i + 3) / 2;
                int tasksToJ = (j - i);
                int result = tasksToI + (tasksToJ + 1) / 2;
                solution = Math.Min(solution, result);
            }
        }

        return solution;
    }
}