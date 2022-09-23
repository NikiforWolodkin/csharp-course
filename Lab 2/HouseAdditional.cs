using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    public partial class House
    {
        public static void IsRenovationRequired(ref int age, int lifetime, out bool result)
        {
            age = age - lifetime;
            result = age > 0;
        }
    }
}
