using Lab_4.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public class MainVMMemento : Memento
    {
        public string Search { get; }
        public object CurrentView { get; }
        public MainVMMemento(MainViewModel mainVM, string search, object currentView) : base(mainVM)
        {
            Search = search;
            CurrentView = currentView;
        }
    }
}
