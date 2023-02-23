using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Book
    {
        public class BookAuthor
        {
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Incoorect author length!")]
            public string Name { get; set; }
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Incoorect country length!")]
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
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Incoorect name length!")]
        public string Name { get; set; }
        public BookAuthor Author { get; set; }
        public int Pages { get; set; }
        [Range(1, 100, ErrorMessage = "Incorrect chapter amount!")]
        public int Chapters { get; set; }
        public Formats Format { get; set; }
        public FileSizes FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Incoorect publisher length!")]
        public string Publisher { get; set; }
        public string AuthorsAndLinks { get; set; }
        public bool IsFree { get; set; }
        [Range(1452, 2023, ErrorMessage = "Incorrect year!")]
        public int Year { get; set; }
        [RegularExpression("[0-9]{1,3}[.][0-9]{1,3}", ErrorMessage = "UDC is not correct!")]
        [UDCAttribute(ErrorMessage = "UDC is not correct!")]
        public string UDC { get; set; }

        public Book()
        {
            Author = new BookAuthor();
            Chapters = 1;
            UploadDate = DateTime.Now;
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
