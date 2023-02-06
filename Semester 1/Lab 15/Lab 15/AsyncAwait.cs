using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public static class AsyncAwait
    {
        public static async void MultiplyVectorAsync(int[] vector)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = vector[i] * 128;
                }
            });
        }
    }
}
