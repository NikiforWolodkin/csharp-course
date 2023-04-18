using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4.Components
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        private static PropertyMetadata _metadata;
        public static readonly DependencyProperty TextProperty;

        private static bool ValidateValue(object value)
        {
            if (value is string text)
            {
                return text != string.Empty;
            }

            return false;
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            string text = (string)baseValue;

            string firstLetter = Convert.ToString(text[0]).ToUpper();
            string otherLetters = text.Substring(1);

            return $"{firstLetter}{otherLetters}";
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        static Header()
        {
            _metadata = new PropertyMetadata("Header");

            _metadata.CoerceValueCallback = CorrectValue;


            TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(Header), _metadata, new ValidateValueCallback(ValidateValue));
        }

        public Header()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
