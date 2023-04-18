using Lab_4.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public class AddOrEditVMMemento : Memento
    {
        public string ImagePath { get; }
        public string Name { get; }
        public string ShortName { get; }
        public string Price { get; }
        public bool InStock { get; }
        public bool CategoryClothing { get; }
        public bool CategoryAccessories { get; }
        public bool CategoryOther { get; }
        public object CurrentView { get; }
        public AddOrEditVMMemento(IHistory VM, string imagePath, string name, string shortName,
            string price, bool inStock, bool clothing, bool accessories, bool other, object currentView) : base(VM)
        {
            ImagePath = imagePath;
            Name = name;
            ShortName = shortName;
            Price = price;
            InStock = inStock;
            CategoryClothing = clothing;
            CategoryAccessories = accessories;
            CategoryOther = other;
            CurrentView = currentView;
        }
    }
}
