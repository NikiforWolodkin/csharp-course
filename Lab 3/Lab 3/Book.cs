using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Book
    {
        public class BookAuthor
        {
            public string Name { get; set; }
            public string Country { get; set; }

            public BookAuthor() { }

            public BookAuthor(string name, string country)
            {
                Name = name;
                Country = country;
            }
        }

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

        public int ID { get; set; }
        public string Name { get; set; }
        public BookAuthor Author { get; set; }
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

        public Book()
        {
            Author = new BookAuthor();
            Chapters = 1;
        }

        public Book(Book book)
        {
            ID = book.ID;
            Name = book.Name;
            Author = new BookAuthor(book.Author.Name, book.Author.Country);
            Pages = book.Pages;
            Chapters = book.Chapters;
            Format = book.Format;
            FileSize = book.FileSize;
            UploadDate = book.UploadDate;
            Publisher = book.Publisher;
            AuthorsAndLinks = book.AuthorsAndLinks;
            IsFree = book.IsFree;
            Year = book.Year;
            UDC = book.UDC;
        }
    }
}
