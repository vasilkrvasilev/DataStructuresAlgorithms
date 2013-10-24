using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

//public class Shop
//{
//    private const string NO_PRODUCT = "No products found";
//    private const string ADD_PRODUCT = "Product added";
//    private const string DELETE_PRODUCT = " products deleted";

//    private readonly MultiDictionary<string, Product> productsByName;
//    private readonly MultiDictionary<string, Product> productsByProducer;
//    private readonly MultiDictionary<string, Product> productsByNameProducer;
//    private readonly OrderedMultiDictionary<double, Product> productsByPrice;

//    public Shop()
//    {
//        productsByName = new MultiDictionary<string, Product>(true);
//        productsByProducer = new MultiDictionary<string, Product>(true);
//        productsByNameProducer = new MultiDictionary<string, Product>(true);
//        productsByPrice = new OrderedMultiDictionary<double, Product>(true);
//    }

//    public string AddProduct(string name, string producer, string price)
//    {
//        double productPrice = double.Parse(price);
//        Product product = new Product(name, producer, productPrice);
//        string nameProducerKey = product.GetNameProducerKey();
//        productsByName.Add(name, product);
//        productsByProducer.Add(producer, product);
//        productsByNameProducer.Add(nameProducerKey, product);
//        productsByPrice.Add(productPrice, product);

//        return ADD_PRODUCT;
//    }

//    public string DeleteProducts(string name, string producer)
//    {
//        string key = name + ";" + producer;
//        var productsToDelete = productsByNameProducer[key];
//        int numberProducts = productsToDelete.Count;
//        if (numberProducts == 0)
//        {
//            return NO_PRODUCT;
//        }
//        else
//        {
//            foreach (var product in productsToDelete)
//            {
//                productsByName.Remove(name, product);
//                productsByProducer.Remove(producer, product);
//                productsByPrice.Remove(product.Price, product);
//            }
//        }

//        productsByNameProducer.Remove(key);
//        return numberProducts + DELETE_PRODUCT;
//    }

//    public string DeleteProducts(string producer)
//    {
//        var productsToDelete = productsByProducer[producer];
//        int numberProducts = productsToDelete.Count;
//        if (numberProducts == 0)
//        {
//            return NO_PRODUCT;
//        }
//        else
//        {
//            foreach (var product in productsToDelete)
//            {
//                productsByName.Remove(product.Name, product);
//                string nameProducerKey = product.GetNameProducerKey();
//                productsByNameProducer.Remove(nameProducerKey, product);
//                productsByPrice.Remove(product.Price, product);
//            }
//        }

//        productsByProducer.Remove(producer);
//        return numberProducts + DELETE_PRODUCT;
//    }

//    public string FindByName(string name)
//    {
//        var productsFound = productsByName[name];
//        int numberProducts = productsFound.Count;
//        if (numberProducts == 0)
//        {
//            return NO_PRODUCT;
//        }
//        else
//        {
//            string output = FormatProducts(productsFound);
//            return output;
//        }
//    }

//    public string FindByProducer(string producer)
//    {
//        var productsFound = productsByProducer[producer];
//        int numberProducts = productsFound.Count;
//        if (numberProducts == 0)
//        {
//            return NO_PRODUCT;
//        }
//        else
//        {
//            string output = FormatProducts(productsFound);
//            return output;
//        }
//    } 

//    public string FindByPrice(string start, string end)
//    {
//        double startPrice = double.Parse(start);
//        double endPrice = double.Parse(end);
//        var productsFound = productsByPrice.Range(startPrice, true, endPrice, true).Values;
//        int numberProducts = productsFound.Count;
//        if (numberProducts == 0)
//        {
//            return NO_PRODUCT;
//        }
//        else
//        {
//            string output = FormatProducts(productsFound);
//            return output;
//        }
//    }

//    private string FormatProducts(ICollection<Product> productsFound)
//    {
//        List<Product> productsList = new List<Product>(productsFound);
//        productsList.Sort();
//        StringBuilder output = new StringBuilder();
//        foreach (var product in productsList)
//        {
//            string productAsString = product.ToString();
//            output.AppendLine(productAsString);
//        }

//        return output.ToString().TrimEnd();
//    }

//    public string ProcessCommand(string command)
//    {
//        int firstSpaceIndex = command.IndexOf(' ');
//        string commandName = command.Substring(0, firstSpaceIndex);
//        string commandData = command.Substring(firstSpaceIndex + 1);
//        string result = string.Empty;
//        if (commandName == "AddProduct")
//        {
//            string[] commandParameters = commandData.Split(';');
//            result = AddProduct(commandParameters[0], commandParameters[2], commandParameters[1]);
//        }
//        else if (commandName == "DeleteProducts")
//        {
//            string[] commandParameters = commandData.Split(';');
//            if (commandParameters.Length == 1)
//            {
//                result = DeleteProducts(commandParameters[0]);
//            }
//            else if (commandParameters.Length == 2)
//            {
//                result = DeleteProducts(commandParameters[0], commandParameters[1]);
//            }
//        }
//        else if (commandName == "FindProductsByName")
//        {
//            result = FindByName(commandData);
//        }
//        else if (commandName == "FindProductsByPriceRange")
//        {
//            string[] commandParameters = commandData.Split(';');
//            result = FindByPrice(commandParameters[0], commandParameters[1]);
//        }
//        else if (commandName == "FindProductsByProducer")
//        {
//            result = FindByProducer(commandData);
//        }
//        else
//        {
//            throw new ArgumentException("Invalid command");
//        }

//        return result;
//    }
//}