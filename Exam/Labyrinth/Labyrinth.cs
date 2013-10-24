using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Labyrinth
{
    public static void Main()
    {
        string[] startInput = Console.ReadLine().Split(' ');
        int startLevel = int.Parse(startInput[0]);
        int startRow = int.Parse(startInput[1]);
        int startColumn = int.Parse(startInput[2]);
        string[] labyrinthInput = Console.ReadLine().Split(' ');
        int labyrinthLevel = int.Parse(labyrinthInput[0]);
        int labyrinthRow = int.Parse(labyrinthInput[1]);
        int labyrinthColumn = int.Parse(labyrinthInput[2]);
        char[, ,] labyrinth = new char[labyrinthLevel, labyrinthRow, labyrinthColumn];
        int[, ,] used = new int[labyrinthLevel, labyrinthRow, labyrinthColumn];

        for (int level = 0; level < labyrinthLevel; level++)
        {
            for (int row = 0; row < labyrinthRow; row++)
            {
                string inputSymbols = Console.ReadLine();
                for (int column = 0; column < labyrinthColumn; column++)
                {
                    labyrinth[level, row, column] = inputSymbols[column];
                }
            }
        }

        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { startLevel, startRow, startColumn });
        used[startLevel, startRow, startColumn] = 1;
        int result = 0;
        while (queue.Count > 0)
        {
            int[] current = queue.Dequeue();
            int steps = used[current[0], current[1], current[2]];
            char symbol = labyrinth[current[0], current[1], current[2]];
            if (symbol == '.' || symbol == 'U' || symbol == 'D')
            {
                if (current[1] + 1 < labyrinthRow && used[current[0], current[1] + 1, current[2]] == 0)
                {
                    queue.Enqueue(new int[] { current[0], current[1] + 1, current[2] });
                    used[current[0], current[1] + 1, current[2]] = steps + 1;
                }
                if (current[1] - 1 >= 0 && used[current[0], current[1] - 1, current[2]] == 0)
                {
                    queue.Enqueue(new int[] { current[0], current[1] - 1, current[2] });
                    used[current[0], current[1] - 1, current[2]] = steps + 1;
                }
                if (current[2] + 1 < labyrinthColumn && used[current[0], current[1], current[2] + 1] == 0)
                {
                    queue.Enqueue(new int[] { current[0], current[1], current[2] + 1 });
                    used[current[0], current[1], current[2] + 1] = steps + 1;
                }
                if (current[2] - 1 >= 0 && used[current[0], current[1], current[2] - 1] == 0)
                {
                    queue.Enqueue(new int[] { current[0], current[1], current[2] - 1 });
                    used[current[0], current[1], current[2] - 1] = steps + 1;
                }
            }

            if (symbol == 'U')
            {
                if (current[0] + 1 < labyrinthLevel && used[current[0] + 1, current[1], current[2]] == 0)
                {
                    queue.Enqueue(new int[] { current[0] + 1, current[1], current[2] });
                    used[current[0] + 1, current[1], current[2]] = steps + 1;
                }
                else
                {
                    result = steps;
                    break;
                }
            }

            if (symbol == 'D')
            {
                if (current[0] - 1 >= 0 && used[current[0] - 1, current[1], current[2]] == 0)
                {
                    queue.Enqueue(new int[] { current[0] - 1, current[1], current[2] });
                    used[current[0] - 1, current[1], current[2]] = steps + 1;
                }
                else
                {
                    result = steps;
                    break;
                }
            }
        }

        Console.WriteLine(result);
    }
}