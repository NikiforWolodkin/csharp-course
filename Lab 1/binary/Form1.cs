namespace binary
{
    public partial class Calculator : Form
    {
        private enum Operations
        {
            AND,
            OR,
            XOR,
            NOT
        }

        private Operations _operations = Operations.AND;
        private int _firstNumber = 0;
        private int _secondNumber = 0;
        private bool _firstIsCorrect = false;
        private bool _secondIsCorrect = false;
        private int _base = 2;

        public Calculator()
        {
            InitializeComponent();
        }

        private void buttonAnd_Click(object sender, EventArgs e)
        {
            _operations = Operations.AND;
            labelOperation.Text = "AND";
            textBoxSecond.Enabled = true;
        }

        private void buttonOr_Click(object sender, EventArgs e)
        {
            _operations = Operations.OR;
            labelOperation.Text = "OR";
            textBoxSecond.Enabled = true;
        }

        private void buttonXor_Click(object sender, EventArgs e)
        {
            _operations = Operations.XOR;
            labelOperation.Text = "XOR";
            textBoxSecond.Enabled = true;
        }

        private void buttonNot_Click(object sender, EventArgs e)
        {
            _operations = Operations.NOT;
            labelOperation.Text = "NOT";
            textBoxSecond.Enabled = false;
            _secondIsCorrect = true;
        }

        private void textBoxFirst_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFirst.Text == "")
            {
                _firstIsCorrect = false;
                return;
            }

            try
            {
                _firstNumber = Convert.ToInt32(textBoxFirst.Text, 2);
                _firstIsCorrect = true;
                labelIncorrectInput.Text = "";
            }
            catch
            {
                _firstIsCorrect = false;
                labelIncorrectInput.Text = "Second input is incorrect!";
            }
        }

        private void textBoxSecond_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSecond.Text == "")
            {
                _secondIsCorrect = false;
                return;
            }

            try
            {
                _secondNumber = Convert.ToInt32(textBoxSecond.Text, 2);
                _secondIsCorrect = true;
                labelIncorrectInput.Text = "";
            }
            catch
            {
                _secondIsCorrect = false;
                labelIncorrectInput.Text = "Second input is incorrect!";
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (_firstIsCorrect == false || _secondIsCorrect == false) return;

            switch (_operations)
            {
                case Operations.AND:
                    labelResult.Text = $"= {Convert.ToString(_firstNumber & _secondNumber, _base)}";
                    break;
                case Operations.OR:
                    labelResult.Text = $"= {Convert.ToString(_firstNumber | _secondNumber, _base)}";
                    break;
                case Operations.XOR:
                    labelResult.Text = $"= {Convert.ToString(_firstNumber ^ _secondNumber, _base)}";
                    break;
                case Operations.NOT:
                    labelResult.Text = $"= {Convert.ToString(~_firstNumber, _base)}";
                    break;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFirst.Text = "";
            textBoxSecond.Text = "";
            _firstNumber = 0;
            _secondNumber = 0;

            _firstIsCorrect = false;
            _secondIsCorrect = false;

            _operations = Operations.AND;
            labelOperation.Text = "AND";
            textBoxSecond.Enabled = true;

            _base = 2;

            labelResult.Text = "=";
        }

        private void buttonBase2_Click(object sender, EventArgs e)
        {
            _base = 2;
        }

        private void buttonBase8_Click(object sender, EventArgs e)
        {
            _base = 8;
        }

        private void buttonBase10_Click(object sender, EventArgs e)
        {
            _base = 10;
        }

        private void buttonBase16_Click(object sender, EventArgs e)
        {
            _base = 16;
        }
    }
}