using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    public class Counter
    {
        public int Number { get; set; } = 0;

        public event EventHandler<EventArgs> RaiseNumberIncreaseEvent;

        protected virtual void OnRaiseNumberIncreaseEvent(EventArgs e)
        {
            EventHandler<EventArgs> raiseEvent = RaiseNumberIncreaseEvent;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }

        public void IncreaseCounter()
        {
            Number++;
            OnRaiseNumberIncreaseEvent(new EventArgs());
        }

        public void SetCounter(int number)
        {
            Number = number;
            OnRaiseNumberIncreaseEvent(new EventArgs());
        }

        public static void Count()
        {
            int amount;
            Console.WriteLine("Введите число: ");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Не верный ввод");
                return;
            }

            for (int i = 1; i <= amount; i++)
            {
                if (i.IsPrime())
                {
                    Console.WriteLine(i);
                    Thread.Sleep(50);
                }
            }
        }

        public static void CountOdd(int amount, int sleepTime)
        {
            for (int i = 1; i <= amount; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(sleepTime);
                }
            }
        }

        public static void CountEven(int amount, int sleepTime)
        {
            for (int i = 1; i <= amount; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(sleepTime);
                }
            }
        }
    }

    public static class Extensions
    {
        /// <summary>
        ///     An Int32 extension method that query if '@this' is prime.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if prime, false if not.</returns>
        public static bool IsPrime(this Int32 @this)
        {
            if (@this == 1 || @this == 2)
            {
                return true;
            }

            if (@this % 2 == 0)
            {
                return false;
            }

            var sqrt = (Int32)Math.Sqrt(@this);
            for (Int64 t = 3; t <= sqrt; t = t + 2)
            {
                if (@this % t == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
