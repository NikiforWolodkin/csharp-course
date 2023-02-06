namespace Lab_1
{
    public partial class Calculator : Form
    {
        private enum Operations
        {
            None,
            Add,
            Subtract,
            Multiply,
            Divide,
            WholeFromDivision,
            DivisionRemainder
        }

        private Operations _operation = Operations.None;
        private double _currentNumber = 0;
        private double _storedNumber = 0;
        private double _memory = 0;
        private bool isCorrect = true;

        public Calculator()
        {
            InitializeComponent();
        }

        private void textBoxInputField_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _currentNumber = Convert.ToDouble(textBoxInputField.Text);
                labelIncorrectInput.Text = "";
                isCorrect = true;
            }
            catch
            {
                if (textBoxInputField.Text != "")
                {
                    isCorrect = false;
                    _currentNumber = 0;
                    labelIncorrectInput.Text = "Incorrect input!";
                }
            }
        }

        private void SetStoredNumber()
        {
            if (textBoxInputField.Text != "")
            {
                _storedNumber = _currentNumber;
                _currentNumber = 0;
                textBoxInputField.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            _operation = Operations.Add;

            SetStoredNumber();

            labelOperation.Text = "+";
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            _operation = Operations.Subtract;

            SetStoredNumber();

            labelOperation.Text = "-";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            _operation = Operations.Multiply;

            SetStoredNumber();

            labelOperation.Text = "*";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            _operation = Operations.Divide;

            SetStoredNumber();

            labelOperation.Text = "/";
        }

        private void buttonWholeFromDivision_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            _operation = Operations.WholeFromDivision;

            SetStoredNumber();

            labelOperation.Text = "/ (int)";
        }

        private void buttonDivisionRemainder_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            _operation = Operations.DivisionRemainder;

            SetStoredNumber();

            labelOperation.Text = "%";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            switch (_operation)
            {
                case Operations.None:
                    return;
                    break;
                case Operations.Add:
                    textBoxInputField.Text = (_storedNumber + _currentNumber).ToString();
                    break;
                case Operations.Subtract:
                    textBoxInputField.Text = (_storedNumber - _currentNumber).ToString();
                    break;
                case Operations.Multiply:
                    textBoxInputField.Text = (_storedNumber * _currentNumber).ToString();
                    break;
                case Operations.Divide:
                    textBoxInputField.Text = (_storedNumber / _currentNumber).ToString();
                    break;
                case Operations.WholeFromDivision:
                    textBoxInputField.Text = ((int)(_storedNumber / _currentNumber)).ToString();
                    break;
                case Operations.DivisionRemainder:
                    textBoxInputField.Text = (_storedNumber % _currentNumber).ToString();
                    break;
            }

            _operation = Operations.None;
            labelOperation.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _operation = Operations.None;
            labelOperation.Text = "";
            _currentNumber = 0;
            _storedNumber = 0;
            isCorrect = true;
            labelIncorrectInput.Text = "";
            textBoxInputField.Text = "";
        }

        private void buttonSaveToMemory_Click(object sender, EventArgs e)
        {
            if (isCorrect == false) return;

            _memory = _currentNumber;
        }

        private void buttonCopyToMemory_Click(object sender, EventArgs e)
        {
            textBoxInputField.Text = _memory.ToString();
        }
    }
}