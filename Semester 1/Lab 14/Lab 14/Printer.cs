using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    public class Printer
    {
        public void SubscribeOdd(Counter publisher)
        {
            publisher.RaiseNumberIncreaseEvent += PrintOdd;
        }

        public void SubscribeEven(Counter publisher)
        {
            publisher.RaiseNumberIncreaseEvent += PrintEven;
        }

        public void PrintOdd(object sender, EventArgs e)
        {
            if (((Counter)sender).Number % 2 == 1)
            {
                Console.WriteLine("Нечетное: " + ((Counter)sender).Number);
            }
        }

        public void PrintEven(object sender, EventArgs e)
        {
            if (((Counter)sender).Number % 2 == 0)
            {
                Console.WriteLine("Четное: " + ((Counter)sender).Number);
            }
        }
    }
}
