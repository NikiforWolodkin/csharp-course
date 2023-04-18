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

namespace Lab_4.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl
    {
        public AddProductView()
        {
            InitializeComponent();
        }

        private const string _commandText = "Keep the “Name” field descriptive and easy to understand.\r\nUse the first letter of each word in the “Name” field to create the “ShortName” field and a add letter or two that signify the type of an item.\r\nIf the “Name” field contains a single word, use the first two letters of that word for the “ShortName” field.\r\nMake sure that the “ShortName” field is unique and not already used by another product.";
        public static RoutedUICommand ShowHelp = new RoutedUICommand(_commandText, "ShowHelp", typeof(EditProductView));

        private void ExecutedCustomCommand(object sender,
        ExecutedRoutedEventArgs e)
        {
            if (e.Command is RoutedUICommand command)
            {
                MessageBox.Show(command.Text, "Help");
            }
        }

        private void CanExecuteCustomCommand(object sender,
        CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
    public partial class EditProductView : UserControl
    {
        public EditProductView()
        {
            InitializeComponent();
        }
    }
}
