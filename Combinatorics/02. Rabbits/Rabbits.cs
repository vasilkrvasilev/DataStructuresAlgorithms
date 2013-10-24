using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Problem 02. Calculate min number of rabbits
public class Rabbits
{
    public static void Main()
    {
        // Read the input
        int elements = int.Parse(Console.ReadLine());
        int[] array = new int[elements];
        for (int count = 0; count < elements; count++)
        {
            array[count] = int.Parse(Console.ReadLine());
        }

        // Sort the array - each n (or m < n) sequential n-1 number represent n different rabbits
        Array.Sort(array);
        int numberRabbits = 0;
        int currentElement = array[0];
        int countSame = 1;
        for (int count = 1; count < elements; count++)
        {
            if (array[count] == currentElement)
            {
                countSame++;
                if (countSame == currentElement + 1)
                {
                    numberRabbits += (currentElement + 1);
                    countSame = 0;
                }
            }
            else
            {
                if (countSame != 0)
                {
                    numberRabbits += (currentElement + 1);
                    currentElement = array[count];
                    countSame = 1;
                }
                else
                {
                    currentElement = array[count];
                    countSame = 1;
                }
            }
        }

        if (countSame != 0)
        {
            numberRabbits += (currentElement + 1);
        }

        Console.WriteLine(numberRabbits);
    }
}