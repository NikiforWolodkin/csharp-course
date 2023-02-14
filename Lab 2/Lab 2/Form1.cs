using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_2
{
    public partial class Library : Form
    {
        private Author _author;
        private Book _book;

        public Library(Author author, Book book)
        {
            InitializeComponent();

            _author = author;
            _book = book;
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
            _author.Name = textBoxAuthorName.Text;

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
            _author.Country = textBoxAuthorCountry.Text;

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
            _author.ID = Convert.ToInt32(maskedTextBoxAuthorID.Text);

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
            if (ValidateChildren())
            {
                if (Save())
                {
                    MessageBox.Show("Saved successfully", "Saved");
                }
            }
        }

        private bool Save()
        {
            try
            {
                string authorJSON = JsonSerializer.Serialize(_author);
                File.WriteAllText(@"../../../../author.json", authorJSON);

                string bookSON = JsonSerializer.Serialize(_book);
                File.WriteAllText(@"../../../../book.json", bookSON);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string authorJSON = File.ReadAllText(@"../../../../author.json");
                _author = JsonSerializer.Deserialize<Author>(authorJSON);
                textBoxAuthorName.Text = _author.Name;
                textBoxAuthorCountry.Text = _author.Country;
                maskedTextBoxAuthorID.Text = _author.ID.ToString();

                string bookJSON = File.ReadAllText(@"../../../../book.json");
                _book = JsonSerializer.Deserialize<Book>(bookJSON);
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
                        hScrollBarFileSize.Value = 0;
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

                MessageBox.Show("Loaded successfully", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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
    }
}