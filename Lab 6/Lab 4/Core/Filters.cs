using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public class Filters
    {
        public string Search { get; set; }
        public double MinimumPrice { get; set; }
        public double MaximumPrice { get; set; }
        public bool[] Categories { get; set; }
        public bool InStockOnly { get; set; }

        public Filters()
        {
            Search = "";
            MinimumPrice = double.MinValue;
            MaximumPrice = double.MaxValue;

            Categories = new bool[3] {true,true,true};

            InStockOnly = false;
        }
    }
}
