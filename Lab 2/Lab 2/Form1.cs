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
            _author.Country = textBoxAuthorName.Text;

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
                _book.Format = Book.Formats.PDF;
            }
            if (radioButtonTXT.Checked)
            {
                _book.Format = Book.Formats.PDF;
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

                MessageBox.Show("Loaded successfully", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}