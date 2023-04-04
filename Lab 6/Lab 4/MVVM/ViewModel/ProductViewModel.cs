using Lab_4.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_4.MVVM.ViewModel
{
    public class ProductViewModel : ObservableObject, IHistory
    {
        private string _page;
        public string Page
        {
            get { return _page; }
            set
            {
                _page = value;
                OnPropertyChanged();
            }
        }
        private string _maxPrice;
        public string MaxPrice
        { 
            get { return _maxPrice; }
            set { 
                _maxPrice = value;
                OnPropertyChanged(); 
            }
        }
        private string _minPrice;
        public string MinPrice
        {
            get { return _minPrice; }
            set
            {
                _minPrice = value;
                OnPropertyChanged();
            }
        }
        public bool InStock { get; set; }
        public bool CategoryClothing { get; set; }
        public bool CategoryAccessories { get; set; }
        public bool CategoryOther { get; set; }

        private List<Core.Product> _selectedproducts;
        public List<Core.Product> SelectedProducts
        {
            get { return _selectedproducts; }
            set
            {
                _selectedproducts = value;
                OnPropertyChanged();
            }
        }

        public void Save()
        {
            ProductVMMemento memento = new ProductVMMemento(this, MaxPrice, MinPrice, InStock, 
                CategoryClothing, CategoryAccessories, CategoryOther, MainViewModel.CurrentView);

            MainViewModel.History.Backup(memento);
        }

        public void Restore(Memento memento)
        {
            if (memento is ProductVMMemento productVMMemento)
            {
                MaxPrice = productVMMemento.MaxPrice;
                if (string.IsNullOrEmpty(MaxPrice))
                {
                    MainViewModel.Filters.MaximumPrice = double.MaxValue;
                }
                else
                {
                    double maxPrice = Convert.ToDouble(MaxPrice);
                    MainViewModel.Filters.MaximumPrice = maxPrice;
                }
                MinPrice = productVMMemento.MinPrice;
                if (string.IsNullOrEmpty(MinPrice))
                {
                    MainViewModel.Filters.MinimumPrice = double.MinValue;
                }
                else
                {
                    double minPrice = Convert.ToDouble(MinPrice);
                    MainViewModel.Filters.MinimumPrice = minPrice;
                }
                CategoryClothing = productVMMemento.CategoryClothing;
                MainViewModel.Filters.Categories[0] = CategoryClothing;
                OnPropertyChanged("CategoryClothing");
                CategoryAccessories = productVMMemento.CategoryAccessories;
                MainViewModel.Filters.Categories[1] = CategoryAccessories;
                OnPropertyChanged("CategoryAccessories");
                CategoryOther = productVMMemento.CategoryOther;
                MainViewModel.Filters.Categories[2] = CategoryOther;
                OnPropertyChanged("CategoryOther");
                InStock = productVMMemento.InStock;
                MainViewModel.Filters.InStockOnly = InStock;
                OnPropertyChanged("InStock");
                MainViewModel.CurrentView = productVMMemento.CurrentView;

                MainViewModel.FilterProducts();

                return;
            }

            throw new InvalidOperationException("Memento is of incorrect type");
        }

        public MainViewModel MainViewModel { get; set; }
        public RelayCommand EditProduct1 { get; set; }
        public RelayCommand EditProduct2 { get; set; }
        public RelayCommand EditProduct3 { get; set; }
        public RelayCommand EditProduct4 { get; set; }
        public RelayCommand EditProduct5 { get; set; }
        public RelayCommand EditProduct6 { get; set; }
        public RelayCommand NextPage { get; set; }
        public RelayCommand PreviousPage { get; set; }
        public RelayCommand EnterMaxPrice { get; set; }
        public RelayCommand EnterMinPrice { get; set; }
        public RelayCommand CheckInStock { get; set; }
        public RelayCommand CheckCategoryClothing { get; set; }
        public RelayCommand CheckCategoryAccessories { get; set; }
        public RelayCommand CheckCategoryOther { get; set; }

        public ProductViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;

            Page = "1";

            InStock = false;
            CategoryClothing = true;
            CategoryAccessories = true;
            CategoryOther = true;

            SelectedProducts = mainViewModel.FilteredProducts.Take(6).ToList();

            EditProduct1 = new RelayCommand(obj => EditProduct(0));
            EditProduct2 = new RelayCommand(obj => EditProduct(1));
            EditProduct3 = new RelayCommand(obj => EditProduct(2));
            EditProduct4 = new RelayCommand(obj => EditProduct(3));
            EditProduct5 = new RelayCommand(obj => EditProduct(4));
            EditProduct6 = new RelayCommand(obj => EditProduct(5));

            NextPage = new RelayCommand(obj =>
            {
                int page = Convert.ToInt32(Page);

                if (mainViewModel.FilteredProducts.Count <= 6 * page)
                {
                    return;
                }

                SelectedProducts = mainViewModel.FilteredProducts.Skip(6 * page).Take(6).ToList();
                if (mainViewModel.FilteredProducts.Count - 6 * page < 6)
                {
                    SelectedProducts.AddRange(Product.EmptyProducts);
                    OnPropertyChanged("SelectedProducts");
                }

                page++;

                Page = page.ToString();
            });

            PreviousPage = new RelayCommand(obj =>
            {
                int page = Convert.ToInt32(Page);

                if (page <= 1)
                {
                    return;
                }

                SelectedProducts = mainViewModel.FilteredProducts.Skip(6 * (page - 2)).Take(6).ToList();

                page--;

                Page = page.ToString();
            });

            EnterMaxPrice = new RelayCommand(obj =>
            {
                if (MaxPrice == "")
                {
                    MainViewModel.Filters.MaximumPrice = double.MaxValue;

                    MainViewModel.FilterProducts();

                    Save();

                    return;
                }

                try
                {
                    double maxPrice = Convert.ToDouble(MaxPrice);

                    MainViewModel.Filters.MaximumPrice = maxPrice;

                    MainViewModel.FilterProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!");
                }

                Save();
            });

            EnterMinPrice = new RelayCommand(obj =>
            {
                if (MinPrice == "")
                {
                    MainViewModel.Filters.MinimumPrice = double.MinValue;

                    MainViewModel.FilterProducts();

                    Save();

                    return;
                }

                try
                {
                    double minPrice = Convert.ToDouble(MinPrice);

                    MainViewModel.Filters.MinimumPrice = minPrice;

                    MainViewModel.FilterProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!");
                }

                Save();
            });

            CheckCategoryClothing = new RelayCommand(obj =>
            {
                MainViewModel.Filters.Categories[0] = CategoryClothing;

                MainViewModel.FilterProducts();

                Save();
            });

            CheckCategoryAccessories = new RelayCommand(obj =>
            {
                MainViewModel.Filters.Categories[1] = CategoryAccessories;

                MainViewModel.FilterProducts();

                Save();
            });

            CheckCategoryOther = new RelayCommand(obj =>
            {
                MainViewModel.Filters.Categories[2] = CategoryOther;

                MainViewModel.FilterProducts();

                Save();
            });

            CheckInStock = new RelayCommand(obj =>
            {
                MainViewModel.Filters.InStockOnly = InStock;

                MainViewModel.FilterProducts();

                Save();
            });
        }

        public void EditProduct(int index)
        {
            if (SelectedProducts[index].Category == Product.Categories.NotAProduct)
            {
                MessageBox.Show("No product to edit!", "No product");
                return;
            }

            MainViewModel.ProductToEdit = SelectedProducts[index];
            MainViewModel.EditProductVM.UpdateUI();
            MainViewModel.CurrentView = MainViewModel.EditProductVM;
        }

        public void UpdateProducts()
        {
            Page = "1";
            SelectedProducts = MainViewModel.FilteredProducts.Take(6).ToList();

            int page = Convert.ToInt32(Page);
            if (MainViewModel.FilteredProducts.Count - 6 * page < 6)
            {
                SelectedProducts.AddRange(Product.EmptyProducts);
                OnPropertyChanged("SelectedProducts");
            }
        }
    }
}
