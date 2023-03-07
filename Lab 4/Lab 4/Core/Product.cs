using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public class Product
    {
        public static List<Product> EmptyProducts { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }

        static Product()
        {
            EmptyProducts = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                EmptyProducts.Add(new Product());
            }
        }

        public Product()
        {
            Name = "No product";
            ImagePath = @"../../Images/noimg.png";
            Price = 0;
        }
    }
}
