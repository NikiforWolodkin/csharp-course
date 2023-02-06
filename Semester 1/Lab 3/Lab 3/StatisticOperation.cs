using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Laba3
{
    public static class StatisticOperation
    {
        public static int Sum(Set set)
        {
            return set.ToArray().Sum();
        }

        public static int DifferenceBetweenMaxAndMin(Set set)
        {
            return (set.ToArray().Max() - set.ToArray().Min());
        }

        public static int AmountOfItems(Set set)
        {
            return (set.Count);
        }

        public static string Encrypt(this string str)
        {
            char[] encryptedString = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                encryptedString[i]++;
            }
            return String.Join("", encryptedString);
        }

        public static string Decrypt(this string str)
        {
            char[] encryptedString = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                encryptedString[i]--;
            }
            return String.Join("", encryptedString);
        }

        public static bool IsSorted(this Set set)
        {
            int[] array = set.ToArray();
            Array.Sort(array);
            return array.SequenceEqual(set.ToArray());
        }
    }
}
