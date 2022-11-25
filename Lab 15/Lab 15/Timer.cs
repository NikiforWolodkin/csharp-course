using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public class Timer
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public void MeasureTask(int[] vector)
        {
            Task task = new Task((vector) => {
                for (int i = 0; i < ((int[])vector).Length; i++)
                {
                    ((int[])vector)[i] = ((int[])vector)[i] * 128;
                }

            }, vector);

            _stopwatch.Restart();
            task.Start();
            _stopwatch.Stop();

            Console.WriteLine(task.IsCompleted + ": " + task.Status);
            Console.WriteLine(_stopwatch.Elapsed);
        }

        public void MeasureAlgorithm(int[] vector)
        {
            _stopwatch.Restart();
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] * 128;
            }
            _stopwatch.Stop();

            Console.WriteLine(_stopwatch.Elapsed);
        }
    }
}
