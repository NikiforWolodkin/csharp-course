using Lab_4.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ProductViewModel ProductVM { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }

        }
        public MainViewModel()
        {
            ProductVM = new ProductViewModel();
            CurrentView = ProductVM;
        }
    }
}
