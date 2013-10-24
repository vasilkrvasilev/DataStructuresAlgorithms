using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Risk
{
    public static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int target = int.Parse(Console.ReadLine());
        int numberForbidden = int.Parse(Console.ReadLine());
        HashSet<int> forbidden = new HashSet<int>();
        for (int count = 0; count < numberForbidden; count++)
        {
            int number = int.Parse(Console.ReadLine());
            forbidden.Add(number);
        }

        int[] used = new int[100000];
        int[] powers = new int[] { 1, 10, 100, 1000, 10000 };
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        while (used[target] == 0 && queue.Count > 0)
        {
            int currentNumber = queue.Dequeue();
            int steps = used[currentNumber];
            for (int power = 0; power < powers.Length; power++)
            {
                int digit = (currentNumber / powers[power]) % 10;
                int numberPlus = 0;
                int numberMinus = 0;
                if (digit == 0)
                {
                    numberPlus = currentNumber + powers[power];
                    numberMinus = currentNumber + 9 * powers[power];
                }
                else if (digit == 9)
                {
                    numberPlus = currentNumber - 9 * powers[power];
                    numberMinus = currentNumber - powers[power];
                }
                else
                {
                    numberPlus = currentNumber + powers[power];
                    numberMinus = currentNumber - powers[power];
                }

                if (used[numberPlus] == 0 && !forbidden.Contains(numberPlus))
                {
                    used[numberPlus] = steps + 1;
                    queue.Enqueue(numberPlus);
                }

                if (used[numberMinus] == 0 && !forbidden.Contains(numberMinus))
                {
                    used[numberMinus] = steps + 1;
                    queue.Enqueue(numberMinus);
                }
            }
        }

        if (used[target] == 0)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(used[target]);
        }
    }
}