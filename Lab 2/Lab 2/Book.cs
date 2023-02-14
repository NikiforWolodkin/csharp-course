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

        public enum FileSizes
        {
            Small,
            Average,
            Big,
            VeryBig,
            Huge
        }

        public string Name { get; set; }
        public int Pages { get; set; }
        public int Chapters { get; set; }
        public Formats Format { get; set; }
        public FileSizes FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string Publisher { get; set; }
        public string AuthorsAndLinks { get; set; }
        public bool IsFree { get; set; }
        public int Year { get; set; }
        public string UDC { get; set; }
    }
}
