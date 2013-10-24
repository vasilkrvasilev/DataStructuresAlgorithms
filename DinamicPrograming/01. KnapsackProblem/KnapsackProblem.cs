using System;

public class KnapsackProblem
{
    public static void Main()
    {
        // Read the input
        Console.WriteLine("Enter max weight");
        int maxWeight = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of products");
        int numberProducts = int.Parse(Console.ReadLine());
        string[] products = new string[numberProducts];
        Console.WriteLine("Enter products weight and price separated by space");
        for (int count = 0; count < numberProducts; count++)
        {
            products[count] = Console.ReadLine();
        }

        // Create matrix to save the results
        int[,] solution = new int[numberProducts + 1, maxWeight + 1];
        for (int row = 1; row <= numberProducts; row++)
        {
            // Parse data for current product
            string[] productData = products[row - 1].Split(' ');
            int weight = int.Parse(productData[0]);
            int price = int.Parse(productData[1]);

            // Update results by adding the new product and iterating through all possible weights
            for (int column = 1; column <= maxWeight; column++)
            {
                // Update of previous result is possible only if its value is different than 0 
                // (there is product/s with this weight)
                if (solution[row - 1,column] > 0)
                {
                    // Rewrite results
                    if (solution[row - 1, column] > solution[row, column])
                    {
                        solution[row, column] = solution[row - 1, column];
                    }

                    // If by adding current product (weight and price), we get better result, than save it
                    if (column + weight <= maxWeight && 
                        solution[row - 1, column] + price > solution[row - 1, column + weight] &&
                        solution[row - 1, column] + price > solution[row, column + weight])
                    {
                        solution[row, column + weight] = solution[row - 1, column] + price;
                    }
                }
            }

            // If by adding current product (weight and price) alone, we get better result, than save it 
            if (weight <= maxWeight && 
                price > solution[row - 1, weight] && 
                price > solution[row, weight])
            {
                solution[row, weight] = price;
            }
        }

        // Find optimal solution by checking the results from the last row of matrix solution
        int maxSolution = 0;
        int index = 0;
        for (int count = 1; count <= maxWeight; count++)
        {
            if (solution[numberProducts, count] > maxSolution)
            {
                maxSolution = solution[numberProducts, count];
                index = count;
            }
        }

        // Print the optimal solution
        Console.WriteLine("Optimal solution is: {0} weight with price {1}", index, maxSolution);
    }
}