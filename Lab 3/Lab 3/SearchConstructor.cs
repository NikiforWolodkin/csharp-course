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
    public partial class SearchConstructor : Form
    {
        private Library _library;
        public SearchConstructor(Library library)
        {
            InitializeComponent();

            _library = library;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                List<Book> books = _library.GetBooks();

                if (textBoxName.Text != "")
                {
                    if (checkBoxNameFullMatches.Checked == true)
                    {
                        books = books
                            .Where(book => book.Name == textBoxName.Text)
                            .ToList();
                    }
                    else
                    {
                        books = books
                            .Where(book => book.Name.ToUpper().Contains(textBoxName.Text.ToUpper()))
                            .ToList();
                    }
                }

                if (textBoxPublisher.Text != "")
                {
                    if (checkBoxPublisherFullMatches.Checked == true)
                    {
                        books = books
                            .Where(book => book.Publisher == textBoxPublisher.Text)
                            .ToList();
                    }
                    else
                    {
                        books = books
                            .Where(book => book.Publisher.ToUpper().Contains(textBoxPublisher.Text.ToUpper()))
                            .ToList();
                    }
                }

                if (textBoxPagesFrom.Text != "")
                {
                    int pageAmount = Convert.ToInt32(textBoxPagesFrom.Text);

                    books = books
                            .Where(book => book.Pages >= pageAmount)
                            .ToList();
                }
                if (textBoxPagesTo.Text != "")
                {
                    int pageAmount = Convert.ToInt32(textBoxPagesTo.Text);

                    books = books
                            .Where(book => book.Pages <= pageAmount)
                            .ToList();
                }

                if (textBoxYearFrom.Text != "")
                {
                    int year = Convert.ToInt32(textBoxYearFrom.Text);

                    books = books
                            .Where(book => book.Year >= year)
                            .ToList();
                }
                if (textBoxYearTo.Text != "")
                {
                    int year = Convert.ToInt32(textBoxYearTo.Text);

                    books = books
                            .Where(book => book.Year >= year)
                            .ToList();
                }

                _library.SetBooks(books);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Close();
            }
        }
    }
}
