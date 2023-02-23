using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_3
{
    public partial class Library : Form
    {
        private Dictionary<int, Book> _books;
        private List<Book> _selectedBooks;
        private Book _book;

        public Library(Book book)
        {
            InitializeComponent();

            _book = book;

            string booksJSON = File.ReadAllText(@"../../../../books.json");
            _books = JsonSerializer.Deserialize<Dictionary<int, Book>>(booksJSON);

            _selectedBooks = _books.Select(book => book.Value).ToList();
            listBoxBooks.Items.AddRange(_selectedBooks.Select(book => book.Name).ToArray());
        }

        private void textBoxAuthorName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAuthorName.Text))
            {
                errorProviderApp.SetError(textBoxAuthorName, "Name should not be left blank!");

                e.Cancel = true;
                textBoxAuthorName.Select(0, textBoxAuthorName.Text.Length);
            }
        }

        private void textBoxAuthorName_Validated(object sender, EventArgs e)
        {
            _book.Author.Name = textBoxAuthorName.Text;

            errorProviderApp.SetError(textBoxAuthorName, "");
        }

        private void textBoxAuthorCountry_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAuthorCountry.Text))
            {
                errorProviderApp.SetError(textBoxAuthorCountry, "Country should not be left blank!");

                e.Cancel = true;
                textBoxAuthorCountry.Select(0, textBoxAuthorCountry.Text.Length);
            }
        }

        private void textBoxAuthorCountry_Validated(object sender, EventArgs e)
        {
            _book.Author.Country = textBoxAuthorCountry.Text;

            errorProviderApp.SetError(textBoxAuthorCountry, "");
        }

        private void maskedTextBoxAuthorID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!maskedTextBoxAuthorID.MaskCompleted)
            {
                errorProviderApp.SetError(maskedTextBoxAuthorID, "ID should not be left blank!");

                e.Cancel = true;
                maskedTextBoxAuthorID.Select(0, maskedTextBoxAuthorID.Text.Length);
            }
        }

        private void maskedTextBoxAuthorID_Validated(object sender, EventArgs e)
        {
            _book.ID = Convert.ToInt32(maskedTextBoxAuthorID.Text);

            errorProviderApp.SetError(maskedTextBoxAuthorID, "");
        }

        private void groupBoxFormat_Leave(object sender, EventArgs e)
        {
            if (radioButtonPDF.Checked)
            {
                _book.Format = Book.Formats.PDF;
            }
            if (radioButtonFB2.Checked)
            {
                _book.Format = Book.Formats.FB2;
            }
            if (radioButtonTXT.Checked)
            {
                _book.Format = Book.Formats.TXT;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            var results = new List<ValidationResult>();
            var context = new ValidationContext(_book);
            if (!Validator.TryValidateObject(_book, context, results, true))
            {
                string errors = "";
                foreach (var error in results)
                {
                    errors += error.ErrorMessage + "\n"; 
                }
                MessageBox.Show(errors, "Invalid input");

                return;
            }

            if (Save())
            {
                MessageBox.Show("Saved successfully", "Saved");
            }
        }

        private bool Save()
        {
            try
            {
                if (_books.ContainsKey(_book.ID))
                {
                    _books.Remove(_book.ID);
                }
                _books.Add(_book.ID, new Book(_book));

                string booksJSON = JsonSerializer.Serialize(_books);
                File.WriteAllText(@"../../../../books.json", booksJSON);

                _selectedBooks = _books.Select(book => book.Value).ToList();
                UpdateBooksList();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        private void UpdateBooksList()
        {
            listBoxBooks.Items.Clear();
            listBoxBooks.Items.AddRange(_selectedBooks.Select(book => book.Name).ToArray());
        }

        private void UpdateBook()
        {
            textBoxAuthorName.Text = _book.Author.Name;
            textBoxAuthorCountry.Text = _book.Author.Country;
            maskedTextBoxAuthorID.Text = _book.ID.ToString();
            switch (_book.Format)
            {
                case Book.Formats.PDF:
                    radioButtonPDF.Checked = true;
                    break;
                case Book.Formats.FB2:
                    radioButtonFB2.Checked = true;
                    break;
                case Book.Formats.TXT:
                    radioButtonTXT.Checked = true;
                    break;
            }
            checkBoxFree.Checked = _book.IsFree;
            dateTimePicker.Value = _book.UploadDate;

            switch (_book.FileSize)
            {
                case Book.FileSizes.Small:
                    labelFileSize.Text = "File size: small";
                    hScrollBarFileSize.Value = 1;
                    break;
                case Book.FileSizes.Average:
                    labelFileSize.Text = "File size: average";
                    hScrollBarFileSize.Value = 21;
                    break;
                case Book.FileSizes.Big:
                    labelFileSize.Text = "File size: big";
                    hScrollBarFileSize.Value = 41;
                    break;
                case Book.FileSizes.VeryBig:
                    labelFileSize.Text = "File size: very big";
                    hScrollBarFileSize.Value = 61;
                    break;
                case Book.FileSizes.Huge:
                    labelFileSize.Text = "File size: huge";
                    hScrollBarFileSize.Value = 81;
                    break;
            }
            richTextBoxAuthorsAndLinks.Text = _book.AuthorsAndLinks;
            textBoxPages.Text = _book.Pages.ToString();
            textBoxUDC.Text = _book.UDC;
            maskedTextBoxYear.Text = _book.Year.ToString();
            textBoxPublisher.Text = _book.Publisher;
            textBoxName.Text = _book.Name;
            numericUpDownChapters.Value = _book.Chapters;
        }

        private void textBoxName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                errorProviderApp.SetError(textBoxName, "Name should not be left blank!");

                e.Cancel = true;
                textBoxName.Select(0, textBoxName.Text.Length);
            }
        }

        private void textBoxName_Validated(object sender, EventArgs e)
        {
            _book.Name = textBoxName.Text;

            errorProviderApp.SetError(textBoxName, "");
        }

        private void hScrollBarFileSize_Scroll(object sender, ScrollEventArgs e)
        {
            switch ((int)(hScrollBarFileSize.Value / 20))
            {
                case 0:
                    labelFileSize.Text = "File size: small";
                    _book.FileSize = Book.FileSizes.Small;
                    break;
                case 1:
                    labelFileSize.Text = "File size: average";
                    _book.FileSize = Book.FileSizes.Average;
                    break;
                case 2:
                    labelFileSize.Text = "File size: big";
                    _book.FileSize = Book.FileSizes.Big;
                    break;
                case 3:
                    labelFileSize.Text = "File size: very big";
                    _book.FileSize = Book.FileSizes.VeryBig;
                    break;
                case 4:
                    labelFileSize.Text = "File size: huge";
                    _book.FileSize = Book.FileSizes.Huge;
                    break;
            }
        }

        private void richTextBoxAuthorsAndLinks_TextChanged(object sender, EventArgs e)
        {
            _book.AuthorsAndLinks = richTextBoxAuthorsAndLinks.Text;
        }

        private void checkBoxFree_CheckedChanged(object sender, EventArgs e)
        {
            _book.IsFree = checkBoxFree.Checked;
        }

        private void maskedTextBoxYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!maskedTextBoxYear.MaskCompleted)
            {
                errorProviderApp.SetError(maskedTextBoxYear, "Year should not be left blank!");

                e.Cancel = true;
                maskedTextBoxYear.Select(0, maskedTextBoxYear.Text.Length);
                return;
            }
        }

        private void maskedTextBoxYear_Validated(object sender, EventArgs e)
        {
            _book.Year = Convert.ToInt32(maskedTextBoxYear.Text);

            errorProviderApp.SetError(maskedTextBoxYear, "");
        }

        private void textBoxUDC_TextChanged(object sender, EventArgs e)
        {
            _book.UDC = textBoxUDC.Text;
        }

        private void textBoxPublisher_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPublisher.Text))
            {
                errorProviderApp.SetError(textBoxPublisher, "Publisher should not be left blank!");

                e.Cancel = true;
                textBoxPublisher.Select(0, textBoxPublisher.Text.Length);
            }
        }

        private void textBoxPublisher_Validated(object sender, EventArgs e)
        {
            _book.Publisher = textBoxPublisher.Text;

            errorProviderApp.SetError(textBoxPublisher, "");
        }

        private void textBoxPages_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(textBoxPages.Text, out _))
            {
                errorProviderApp.SetError(textBoxPages, "Pages should contain a number!");

                e.Cancel = true;
                textBoxPages.Select(0, textBoxPages.Text.Length);
            }
        }

        private void textBoxPages_Validated(object sender, EventArgs e)
        {
            _book.Pages = Convert.ToInt32(textBoxPages.Text);

            errorProviderApp.SetError(textBoxPages, "");
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _book.UploadDate = dateTimePicker.Value;
        }

        private void numericUpDownChapters_ValueChanged(object sender, EventArgs e)
        {
            _book.Chapters = (int)numericUpDownChapters.Value;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Nikifor Valodzkin, V. 0.2.0", "About");
        }

        private void Library_Load(object sender, EventArgs e)
        {
            ActiveControl = labelBooks;
        }

        private void hideToolStripButton_Click(object sender, EventArgs e)
        {
            toolStrip.Hide();
            buttonShowToolStrip.Show();
        }

        private void buttonShowToolStrip_Click(object sender, EventArgs e)
        {
            toolStrip.Show();
            buttonShowToolStrip.Hide();
        }

        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedIndex == -1)
            {
                return;
            }

            _book = _selectedBooks[listBoxBooks.SelectedIndex];
            UpdateBook();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_books.ContainsKey(_book.ID))
                {
                    MessageBox.Show("Can't find the book with specified ID", "Error");
                    return;
                }

                _books.Remove(_book.ID);

                string booksJSON = JsonSerializer.Serialize(_books);
                File.WriteAllText(@"../../../../books.json", booksJSON);

                MessageBox.Show("Deleted succesfully", "Deleted");

                _selectedBooks = _books.Select(book => book.Value).ToList();
                UpdateBooksList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            _book = new Book();
            UpdateBook();
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedBooks = _selectedBooks.OrderBy(book => book.Name).ToList();
            UpdateBooksList();
        }

        private void byUploadDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedBooks = _selectedBooks.OrderBy(book => book.UploadDate).ToList();
            UpdateBooksList();
        }

        private void saveSearchResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string booksJSON = JsonSerializer.Serialize(_books);
                File.WriteAllText(@"../../../../selectedBooks.json", booksJSON);

                MessageBox.Show("Search results saved successfully", "Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public List<Book> GetBooks() => _books.Select(book => book.Value).ToList();

        public void SetBooks(List<Book> books)
        {
            _selectedBooks = books;
            UpdateBooksList();
        }

        private void byNameToolStripMenuItemSearch_Click(object sender, EventArgs e)
        {
            Search search = new Search(this);
            search.Show();
        }

        private void byPublisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchByPublisher search = new SearchByPublisher(this);
            search.Show();
        }

        private void byYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchByYear search = new SearchByYear(this);
            search.Show();
        }

        private void byPageAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchByPageAmount search = new SearchByPageAmount(this);
            search.Show();
        }

        private void searchQueryConstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchConstructor searchConstructor = new SearchConstructor(this);
            searchConstructor.Show();
        }

        private void upToolStripButton_Click(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedIndex == -1)
            {
                listBoxBooks.SelectedIndex = 0;
                return;
            }

            if (listBoxBooks.SelectedIndex < listBoxBooks.Items.Count - 1)
            {
                listBoxBooks.SelectedIndex++;
            }
        }

        private void downToolStripButton_Click(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedIndex == -1)
            {
                listBoxBooks.SelectedIndex = 0;
                return;
            }

            if (listBoxBooks.SelectedIndex > 0)
            {
                listBoxBooks.SelectedIndex--;
            }
        }
    }
}