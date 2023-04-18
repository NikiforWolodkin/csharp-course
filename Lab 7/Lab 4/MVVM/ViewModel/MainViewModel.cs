using Lab_4.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_4.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject, IHistory
    {
        private string _language;
        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;

                OnPropertyChanged();
            }
        }
        private string _theme;
        public string Theme
        {
            get { return _theme; }
            set
            {
                _theme = value;

                OnPropertyChanged();
            }
        }
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                Filters.Search = value;

                OnPropertyChanged();
            }
        }

        private Filters _filters;
        public Filters Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;

                FilterProducts();

                OnPropertyChanged();
            }
        }
        public List<Core.Product> Products { get; set; }
        public Core.Product ProductToEdit { get; set; }
        private List<Core.Product> _filteredProducts;
        public List<Core.Product> FilteredProducts
        {
            get { return _filteredProducts; }
            set
            {
                _filteredProducts = value;

                OnPropertyChanged();
            }
        }
        public Caretaker History{ get; set; }

        public void Save()
        {
            MainVMMemento memento = new MainVMMemento(this, Search, CurrentView);
            History.Backup(memento);
        }

        public void Restore(Memento memento)
        {
            if (memento is MainVMMemento mainVMMemento)
            {
                Search = mainVMMemento.Search;
                CurrentView = mainVMMemento.CurrentView;

                FilterProducts();

                return;
            }

            throw new InvalidOperationException("Memento is of incorrect type");
        }

        public RelayCommand EnterSearch { get; set; }
        public RelayCommand AddProduct { get; set; }
        public RelayCommand ChangeLanguage { get; set; }
        public RelayCommand ChangeTheme { get; set; }
        public RelayCommand ChangeViewModel { get; set; }
        public RelayCommand Undo { get; set; }
        public RelayCommand Redo { get; set; }

        public ProductViewModel ProductVM { get; set; }
        public AddProductViewModel AddProductVM { get; set; }
        public EditProductViewModel EditProductVM { get; set; }
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
            DeserializeProducts();

            Language = "EN";
            Theme = "DK";

            FilteredProducts = Products;

            History = new Caretaker();

            ProductVM = new ProductViewModel(this);
            AddProductVM = new AddProductViewModel(this);
            EditProductVM = new EditProductViewModel(this);
            CurrentView = ProductVM;

            Filters = new Filters();

            Search = "";

            History.ClearStacks();
            Save();
            ProductVM.Save();

            Undo = new RelayCommand(obj =>
            {
                History.Undo();
            });

            Redo = new RelayCommand(obj =>
            {
                History.Redo();
            });

            EnterSearch = new RelayCommand(obj =>
            {
                FilterProducts();

                CurrentView = ProductVM;

                Save();
            });

            AddProduct = new RelayCommand(obj =>
            {
                CurrentView = AddProductVM;

                Save();
            });

            ChangeLanguage = new RelayCommand(obj =>
            {
                var app = Application.Current;

                if (Language == "EN")
                {
                    var uriRU = new Uri("../../Locales/LocaleRU.xaml", UriKind.Relative);

                    app.Resources.MergedDictionaries[0].MergedDictionaries.Clear();
                    app.Resources.MergedDictionaries[0].MergedDictionaries.Add(new ResourceDictionary() { Source = uriRU });

                    Language = "RU";

                    return;
                }

                
                var uriEN = new Uri("../../Locales/LocaleEN.xaml", UriKind.Relative);

                app.Resources.MergedDictionaries[0].MergedDictionaries.Clear();
                app.Resources.MergedDictionaries[0].MergedDictionaries.Add(new ResourceDictionary() { Source = uriEN });

                Language = "EN";
            });

            ChangeTheme = new RelayCommand(obj =>
            {
                var app = Application.Current;

                if (Theme == "DK")
                {
                    var uriRU = new Uri("../../Theme/LightTheme.xaml", UriKind.Relative);

                    app.Resources.MergedDictionaries[1].MergedDictionaries.Clear();
                    app.Resources.MergedDictionaries[1].MergedDictionaries.Add(new ResourceDictionary() { Source = uriRU });

                    Theme = "LT";

                    return;
                }

                if (Theme == "LT")
                {
                    var uriRU = new Uri("../../Theme/PinkTheme.xaml", UriKind.Relative);

                    app.Resources.MergedDictionaries[1].MergedDictionaries.Clear();
                    app.Resources.MergedDictionaries[1].MergedDictionaries.Add(new ResourceDictionary() { Source = uriRU });

                    Theme = "PK";

                    return;
                }


                var uriEN = new Uri("../../Theme/DarkTheme.xaml", UriKind.Relative);

                app.Resources.MergedDictionaries[1].MergedDictionaries.Clear();
                app.Resources.MergedDictionaries[1].MergedDictionaries.Add(new ResourceDictionary() { Source = uriEN });

                Theme = "DK";
            });

            ChangeViewModel = new RelayCommand(obj =>
            {
                CurrentView = ProductVM;
            });
        }

        public void FilterProducts()
        {
            var filteredProducts = Products
                .Where(product => product.Name.ToUpper().Contains(Filters.Search.ToUpper()));

            if (Filters.InStockOnly == true)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.InStock != false);
            }

            filteredProducts = filteredProducts
                .Where(product => product.Price <= Filters.MaximumPrice);

            filteredProducts = filteredProducts
                .Where(product => product.Price >= Filters.MinimumPrice);

            if (Filters.Categories[0] == false)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.Category != Product.Categories.Clothing);
            }

            if (Filters.Categories[1] == false)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.Category != Product.Categories.Accessories);
            }

            if (Filters.Categories[2] == false)
            {
                filteredProducts = filteredProducts
                    .Where(product => product.Category != Product.Categories.Other);
            }

            FilteredProducts = filteredProducts.ToList();

            ProductVM.UpdateProducts();
        }

        public void SerializeProducts()
        {
            string json = JsonSerializer.Serialize(Products);
            File.WriteAllText(@"../../../Products.json", json);
        }

        public void DeserializeProducts()
        {
            string json = File.ReadAllText(@"../../../Products.json");
            Products = JsonSerializer.Deserialize<List<Core.Product>>(json);
        }
    }
}
