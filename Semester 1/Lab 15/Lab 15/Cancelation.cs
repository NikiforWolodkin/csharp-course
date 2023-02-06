using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public static class Cancelation
    {
        public static void ShowTaskCancelation(int[] vector)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task = new Task((vector) => {
                for (int i = 0; i < ((int[])vector).Length; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    ((int[])vector)[i] = ((int[])vector)[i] * 128;
                }
            }, vector, token);

            task.Start();
            cancelTokenSource.Cancel();

            Console.WriteLine(task.IsCompleted + ": " + task.Status);
        }
    }
}
