using Lab_4.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public class ProductVMMemento : Memento
    {
        public string MaxPrice { get; }
        public string MinPrice { get; }
        public bool InStock { get; }
        public bool CategoryClothing { get; }
        public bool CategoryAccessories { get; }
        public bool CategoryOther { get; }
        public object CurrentView { get; }
        public ProductVMMemento(ProductViewModel productVM, string maxPrice, string minPrice,
            bool inStock, bool clothing, bool acessories, bool other, object currentView) : base(productVM)
        {
            MaxPrice = maxPrice;
            MinPrice = minPrice;
            InStock = inStock;
            CategoryClothing = clothing;
            CategoryAccessories = acessories;
            CategoryOther = other;
            CurrentView = currentView;
        }
    }
}
