using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class ProductList
{
    private const int NUMBER_PRODUCTS = 20;
    private static char[] separators = new char[] { ' ', '\t' };

    public static void Main()
    {
        // Generate product list from file
        Console.WriteLine("Enter the name of the information file");   //products.txt
        string productFile = Console.ReadLine();
        OrderedMultiDictionary<double, string> productList =
            GenerateProductList(productFile);

        // Read commands from file and execute them
        Console.WriteLine("Enter the name of the command file");       //commands.txt
        string commandFile = Console.ReadLine();
        Console.WriteLine(HandleCommands(commandFile, productList));
    }

    /// <summary>
    /// Read file and add element to the product list (price with name)
    /// </summary>
    /// <param name="file">File name</param>
    /// <exception cref="ArgumentNullException">
    /// If the file name is null or white space</exception>
    /// <remarks>Use UTF-8 encoding</remarks>
    /// <returns>Created product list</returns>
    public static OrderedMultiDictionary<double, string> GenerateProductList(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            throw new ArgumentNullException(
                "invalid input! File name cannot be null or white space");
        }

        OrderedMultiDictionary<double, string> productList =
            new OrderedMultiDictionary<double, string>(true);
        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] content = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                double price = double.Parse(content[1]);
                string name = content[0];
                productList.Add(price, name);
                line = reader.ReadLine();
            }
        }

        return productList;
    }

    /// <summary>
    /// Read commands (find) from file and execute them searching in given product list
    /// </summary>
    /// <param name="file">File name</param>
    /// <param name="phoneBook">Product list to search in</param>
    /// <remarks>Use UTF-8 encoding</remarks>
    /// <exception cref="ArgumentNullException">
    /// If the file name is null or white space or the product list is empty</exception>
    /// <exception cref="InvalidOperationException">
    /// If current command is invalid</exception>
    /// <returns>String representation of found products from all searches</returns>
    public static string HandleCommands(string file, OrderedMultiDictionary<double, string> productList)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            throw new ArgumentNullException(
                "invalid input! File name cannot be null or white space");
        }

        if (productList == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Product list cannot be empty.");
        }

        StringBuilder resultLists = new StringBuilder();
        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] content = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (content.Length > 1)
                {
                    double startPrice = double.Parse(content[0]);
                    double endPrice = double.Parse(content[1]);
                    if (content.Length == 2)
                    {
                        string result = FindProducts(startPrice, endPrice, NUMBER_PRODUCTS, productList);
                        resultLists.AppendLine(result);
                    }
                    else if (content.Length == 3)
                    {
                        int numberProducts = int.Parse(content[2]);
                        string result = FindProducts(startPrice, endPrice, numberProducts, productList);
                        resultLists.AppendLine(result);
                    }
                }
                else
                {
                    throw new InvalidOperationException(
                        "Invalid command! Valid command format: price price and price price number products");
                }

                line = reader.ReadLine();
            }
        }

        return resultLists.ToString();
    }

    /// <summary>
    /// Find products in the product list with price in given interval
    /// </summary>
    /// <param name="startPrice">Start value of the interal</param>
    /// <param name="endPrice">End value of the interal</param>
    /// <param name="numberProducts">Number of product to select</param>
    /// <param name="productList">Product list to search in</param>
    /// <exception cref="ArgumentNullException">
    /// If the product list is empty</exception>
    /// <returns>String representation of found products</returns>
    private static string FindProducts(double startPrice, double endPrice, int numberProducts, 
        OrderedMultiDictionary<double, string> productList)
    {
        if (productList == null)
        {
            throw new ArgumentNullException(
                "Invalid input! Product list cannot be empty.");
        }

        int count = 0;
        StringBuilder result = new StringBuilder();
        OrderedMultiDictionary<double, string>.View foundProducts = 
            productList.Range(startPrice, true, endPrice, true);

        result.AppendLine(string.Format(
            "First {2} products in the price interval [{0}, {1}] are:", 
            startPrice, endPrice, numberProducts));
        foreach (var product in foundProducts)
        {
            if (count >= numberProducts)
            {
                break;
            }

            result.AppendLine(string.Format(
                "Product: {0}, Price: {1}", product.Value, product.Key));
            count++;
        }

        return result.ToString();
    }
}