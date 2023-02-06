using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public class Continuation
    {
        private static void _printVector(Task task)
        {
            for (int i = 0; i < ((Task<int[]>)task).Result.Length; i += 10000)
            {
                Console.WriteLine(((Task<int[]>)task).Result[i]);
            }
        }

        public static void ShowContinuationWithContinue(int[] vector)
        {
            Task<int[]> task1 = new Task<int[]>(() =>
            {
                for (int i = 0; i < ((int[])vector).Length; i++)
                {
                    ((int[])vector)[i] = ((int[])vector)[i] * 128;
                }
                return vector;
            });

            Task task2 = task1.ContinueWith(_printVector);

            task1.Start();
            task2.Wait();
        }

        public static void ShowContinuationAwaiter(int[] vector)
        {
            Task<int[]> task = new Task<int[]>(() =>
            {
                for (int i = 0; i < ((int[])vector).Length; i++)
                {
                    ((int[])vector)[i] = ((int[])vector)[i] * 128;
                }
                return vector;
            });

            task.Start();

            int[] vectorUpdated = task.GetAwaiter().GetResult();
            for (int i = 0; i < vectorUpdated.Length; i += 10000)
            {
                Console.WriteLine(vectorUpdated[i]);
            }
        }
    }
}
