using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Search : Form
    {
        protected Library Library;
        public Search(Library library)
        {
            InitializeComponent();

            labelSearchBy.Text = "Search by name";

            Library = library;
        }

        protected virtual void buttonFind_Click(object sender, EventArgs e)
        {
            List<Book> books = Library.GetBooks();

            List<Book> selectedBooks = books
                .Where(book => book.Name.ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                .ToList();

            Library.SetBooks(selectedBooks);

            Close();
        }
    }

    public partial class SearchByPublisher : Search
    {
        public SearchByPublisher(Library library) : base(library)
        {
            labelSearchBy.Text = "Search by publisher";
        }

        protected override void buttonFind_Click(object sender, EventArgs e)
        {
            List<Book> books = Library.GetBooks();

            List<Book> selectedBooks = books
                .Where(book => book.Publisher.ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                .ToList();

            Library.SetBooks(selectedBooks);

            Close();
        }
    }

    public partial class SearchByYear : Search
    {
        public SearchByYear(Library library) : base(library)
        {
            labelSearchBy.Text = "Search by year";
        }

        protected override void buttonFind_Click(object sender, EventArgs e)
        {
            List<Book> books = Library.GetBooks();

            int year = 0;
            try
            {
                year = Convert.ToInt32(textBoxSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Close();
            }

            List<Book> selectedBooks = books
                .Where(book => book.Year == year)
                .ToList();

            Library.SetBooks(selectedBooks);

            Close();
        }
    }

    public partial class SearchByPageAmount : Search
    {
        public SearchByPageAmount(Library library) : base(library)
        {
            labelSearchBy.Text = "Search by page amount";
        }

        protected override void buttonFind_Click(object sender, EventArgs e)
        {
            List<Book> books = Library.GetBooks();

            int pageAmount = 0;
            try
            {
                pageAmount = Convert.ToInt32(textBoxSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Close();
            }

            List<Book> selectedBooks = books
                .Where(book => book.Pages == pageAmount)
                .ToList();

            Library.SetBooks(selectedBooks);

            Close();
        }
    }
}
