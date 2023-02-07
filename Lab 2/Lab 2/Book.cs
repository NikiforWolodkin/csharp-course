using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Book
    {
        public enum Formats
        {
            PDF,
            FB2,
            TXT
        }

        public Formats Format { get; set; }
    }
}
