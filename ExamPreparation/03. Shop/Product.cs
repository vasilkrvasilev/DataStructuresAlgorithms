using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//public class Product : IComparable<Product>
//{
//    public string Name { get; set; }
//    public string Producer { get; set; }
//    public double Price { get; set; }

//    public Product(string name, string producer, double price)
//    {
//        this.Name = name;
//        this.Producer = producer;
//        this.Price = price;
//    }

//    public string GetNameProducerKey()
//    {
//        string nameProducerKey = string.Format("{0};{1}", this.Name, this.Producer);
//        return nameProducerKey;
//    }

//    public int CompareTo(Product other)
//    {
//        int result = this.Name.CompareTo(other.Name);
//        if (result == 0)
//        {
//            result = this.Producer.CompareTo(other.Producer);
//            if (result == 0)
//            {
//                result = this.Price.CompareTo(this.Price);
//            }
//        }

//        return result;
//    }

//    public override string ToString()
//    {
//        string result = "{" + this.Name + ";" + this.Producer + ";" + this.Price.ToString("0.00") + "}";
//        return result;
//    }
//}