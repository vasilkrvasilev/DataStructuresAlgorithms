using System;
using System.Collections.Generic;
using System.Linq;

public class Coins
{
    public static void Main()
    {
        // Read the input
        Console.WriteLine("Enter amount");
        int amount = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of types of coins");
        int typeOfCoins = int.Parse(Console.ReadLine());
        SortedDictionary<int, int> coins = new SortedDictionary<int, int>();
        Console.WriteLine("Enter type of coin and its number separated by space");
        for (int count = 0; count < typeOfCoins; count++)
        {
            string input = Console.ReadLine();
            string[] inputData = input.Split(' ');
            coins.Add(int.Parse(inputData[0]), int.Parse(inputData[1]));
        }

        // Get each time from the bigger possible coin type 
        // Till there are more coins and did not ecxeeded the amount
        Dictionary<int, int> used = new Dictionary<int, int>();
        while (coins.Count > 0 && amount > 0)
        {
            int maxType = coins.Keys.Max();
            int maxNumber = coins[maxType];
            used.Add(maxType, 0);
            while (coins[maxType] > 0 && amount >= maxType)
            {
                amount -= maxType;
                coins[maxType]--;
                used[maxType]++;
            }

            coins.Remove(maxType);
        }

        foreach (var item in used)
        {
            Console.WriteLine("{0} coin {1} times = {2}", item.Key, item.Value, item.Key * item.Value);
        }
    }
}