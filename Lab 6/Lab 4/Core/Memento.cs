using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public class Memento
    {
        public DateTime Timestamp { get; set; }
        public IHistory Originator { get; set; }
        public Memento(IHistory originator)
        {
            Timestamp = DateTime.Now;
            Originator = originator;
        }
    }
}
