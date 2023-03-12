using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public class Product
    {
        public enum Categories
        {
            Clothing,
            Accessories,
            Other,
            NotAProduct
        }

        public static List<Product> EmptyProducts { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public Categories Category { get; set; }
        public bool InStock { get; set; }

        static Product()
        {
            EmptyProducts = new List<Product>();
            for (int i = 0; i < 6; i++)
            {
                EmptyProducts.Add(new Product());
            }
        }

        public Product()
        {
            Name = "No product";
            ShortName = "NOPR";
            ImagePath = @"../../Images/noimg.png";

            Price = 0;

            Category = Categories.NotAProduct;
            InStock = false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Product product)
            {
                return ShortName == product.ShortName;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ShortName.GetHashCode();
        }
    }
}
