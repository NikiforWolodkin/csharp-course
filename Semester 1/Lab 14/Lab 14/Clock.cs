using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    public class Clock
    {
        private int _seconds { get; set; }

        public Clock()
        {
            _seconds = 0;
        }

        public void Timer(Object time)
        {
            if (((DateTime)time) > DateTime.Now)
            {
                Console.WriteLine(_seconds);
                _seconds++;
            }
        }
    }
}
