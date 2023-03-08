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
    public class MainViewModel : ObservableObject
    {
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
        public RelayCommand EnterSearch { get; set; }
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
            DeserializeProducts();
            SerializeProducts();

            FilteredProducts = Products;

            ProductVM = new ProductViewModel(this);
            CurrentView = ProductVM;

            Filters = new Filters();

            EnterSearch = new RelayCommand(obj =>
            {
                FilterProducts();
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
