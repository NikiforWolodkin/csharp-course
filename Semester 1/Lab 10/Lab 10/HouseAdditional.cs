using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_10
{
    public partial class House
    {
        public static void IsRenovationRequired(ref int age, int lifetime, out bool result)
        {
            age = age - lifetime;
            result = age > 0;
        }
    }

    public class Street
    {
        public string Name;
        public int AmountOfHouses;

        public Street(string name = "", int amountOfHouses = 0)
        {
            Name = name;
            AmountOfHouses = amountOfHouses;
        }
    }
}
