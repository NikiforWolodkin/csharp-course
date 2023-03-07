using Lab_4.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab_4.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public List<Core.Product> Products { get; set; }
        public List<Core.Product> FilteredProducts { get; set; }
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

            FilteredProducts = Products;

            ProductVM = new ProductViewModel(this);
            CurrentView = ProductVM;
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
