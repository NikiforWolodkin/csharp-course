using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public static class Parallelity
    {
        private static Stopwatch _stopwatch = new Stopwatch();
        private static Random _random = new Random();

        public static void ShowParallelFor()
        {
            int[] array = new int[100000];

            void randomizeArray(int index)
            {
                array[index] = _random.Next(1, 1000);
            }

            _stopwatch.Restart();
            Parallel.For(0, array.Length, randomizeArray);
            _stopwatch.Stop();

            Console.WriteLine(_stopwatch.Elapsed);
        }

        public static void ShowFor()
        {
            int[] array = new int[100000];

            _stopwatch.Restart();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = _random.Next(1, 1000);
            }
            _stopwatch.Stop();

            Console.WriteLine(_stopwatch.Elapsed);
        }

        public static void ShowParallelForeach()
        {
            List<string> list = new List<string>();
            List<string> listUpdated = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                list.Add("Hello World!");
            }

            void formatStrings(string str)
            {
                listUpdated.Add(str.Replace(" ", "_"));
            }

            _stopwatch.Restart();
            ParallelLoopResult result = Parallel.ForEach(list, formatStrings);
            _stopwatch.Stop();

            Console.WriteLine(_stopwatch.Elapsed);
        }
    }
}
