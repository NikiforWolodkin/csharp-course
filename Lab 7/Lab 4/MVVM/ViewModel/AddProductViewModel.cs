using Lab_4.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab_4.MVVM.ViewModel
{
    public class AddProductViewModel : ObservableObject, IHistory
    {
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;

                Save();

                OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                Save();

                OnPropertyChanged();
            }
        }
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set
            {
                _shortName = value;

                Save();

                OnPropertyChanged();
            }
        }
        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;

                Save();

                OnPropertyChanged();
            }
        }

        public bool CheckClothing { get; set; }
        public bool CheckAccessories { get; set; }
        public bool CheckOther { get; set; }
        public bool InStock { get; set; }

        public void Save()
        {
            AddOrEditVMMemento memento = new AddOrEditVMMemento(this, ImagePath, Name,
                ShortName, Price, InStock, CheckClothing, CheckAccessories, CheckOther, MainViewModel.CurrentView);

            MainViewModel.History.Backup(memento);
        }

        public void Restore(Memento memento)
        {
            if (memento is AddOrEditVMMemento addOrEditVMemento)
            {
                _price = addOrEditVMemento.Price;
                OnPropertyChanged("Price");
                _name = addOrEditVMemento.Name;
                OnPropertyChanged("Name");
                _shortName = addOrEditVMemento.ShortName;
                OnPropertyChanged("ShortName");
                _imagePath = addOrEditVMemento.ImagePath;
                OnPropertyChanged("ImagePath");
                CheckClothing = addOrEditVMemento.CategoryClothing;
                OnPropertyChanged("CheckClothing");
                CheckAccessories = addOrEditVMemento.CategoryAccessories;
                OnPropertyChanged("CheckAccessories");
                CheckOther = addOrEditVMemento.CategoryOther;
                OnPropertyChanged("CheckOther");
                InStock = addOrEditVMemento.InStock;
                OnPropertyChanged("InStock");
                MainViewModel.CurrentView = addOrEditVMemento.CurrentView;

                return;
            }

            throw new InvalidOperationException("Memento is of incorrect type");
        }

        public MainViewModel MainViewModel { get; set; }
        public RelayCommand AddProduct { get; set; }
        public RelayCommand SaveChecks { get; set; }
        public AddProductViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;

            ImagePath = "../../Images/noimg.png";
            Name = "";
            ShortName = "";
            Price = "";

            CheckClothing = true;

            SaveChecks = new RelayCommand(obj =>
            {
                Save();
            });

            AddProduct = new RelayCommand(obj =>
            {
                Core.Product product = new Product();

                product.Name = Name;
                product.ShortName = ShortName;
                product.ImagePath = ImagePath;
                product.InStock = InStock;
                
                double price = 0;
                try
                {
                    price = Convert.ToDouble(Price);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!", ex.Message);
                    return;
                }
                product.Price = price;

                if (CheckClothing == true)
                {
                    product.Category = Product.Categories.Clothing;
                }
                if (CheckAccessories == true)
                {
                    product.Category = Product.Categories.Accessories;
                }
                if (CheckOther == true)
                {
                    product.Category = Product.Categories.Other;
                }

                MainViewModel.Products.Add(product);
                MainViewModel.FilterProducts();
                MainViewModel.SerializeProducts();
                MainViewModel.CurrentView = MainViewModel.ProductVM;
            });
        }
    }
}
