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
    public class ProductViewModel : ObservableObject
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

            EditProduct1 = new RelayCommand(obj =>
            {
                if (SelectedProducts[0].Category == Product.Categories.NotAProduct)
                {
                    MessageBox.Show("No product to edit!", "No product");
                    return;
                }

                MainViewModel.ProductToEdit = SelectedProducts[0];
                MainViewModel.EditProductVM.UpdateUI();
                MainViewModel.CurrentView = MainViewModel.EditProductVM;
            });
            EditProduct2 = new RelayCommand(obj =>
            {
                if (SelectedProducts[1].Category == Product.Categories.NotAProduct)
                {
                    MessageBox.Show("No product to edit!", "No product");
                    return;
                }

                MainViewModel.ProductToEdit = SelectedProducts[1];
                MainViewModel.EditProductVM.UpdateUI();
                MainViewModel.CurrentView = MainViewModel.EditProductVM;
            });
            EditProduct3 = new RelayCommand(obj =>
            {
                if (SelectedProducts[2].Category == Product.Categories.NotAProduct)
                {
                    MessageBox.Show("No product to edit!", "No product");
                    return;
                }

                MainViewModel.ProductToEdit = SelectedProducts[2];
                MainViewModel.EditProductVM.UpdateUI();
                MainViewModel.CurrentView = MainViewModel.EditProductVM;
            });
            EditProduct4 = new RelayCommand(obj =>
            {
                if (SelectedProducts[3].Category == Product.Categories.NotAProduct)
                {
                    MessageBox.Show("No product to edit!", "No product");
                    return;
                }

                MainViewModel.ProductToEdit = SelectedProducts[3];
                MainViewModel.EditProductVM.UpdateUI();
                MainViewModel.CurrentView = MainViewModel.EditProductVM;
            });
            EditProduct5 = new RelayCommand(obj =>
            {
                if (SelectedProducts[4].Category == Product.Categories.NotAProduct)
                {
                    MessageBox.Show("No product to edit!", "No product");
                    return;
                }

                MainViewModel.ProductToEdit = SelectedProducts[4];
                MainViewModel.EditProductVM.UpdateUI();
                MainViewModel.CurrentView = MainViewModel.EditProductVM;
            });
            EditProduct6 = new RelayCommand(obj =>
            {
                if (SelectedProducts[5].Category == Product.Categories.NotAProduct)
                {
                    MessageBox.Show("No product to edit!", "No product");
                    return;
                }

                MainViewModel.ProductToEdit = SelectedProducts[5];
                MainViewModel.EditProductVM.UpdateUI();
                MainViewModel.CurrentView = MainViewModel.EditProductVM;
            });

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
            });

            EnterMinPrice = new RelayCommand(obj =>
            {
                if (MinPrice == "")
                {
                    MainViewModel.Filters.MinimumPrice = double.MinValue;

                    MainViewModel.FilterProducts();

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
            });

            CheckCategoryClothing = new RelayCommand(obj =>
            {
                MainViewModel.Filters.Categories[0] = CategoryClothing;

                MainViewModel.FilterProducts();
            });

            CheckCategoryAccessories = new RelayCommand(obj =>
            {
                MainViewModel.Filters.Categories[1] = CategoryAccessories;

                MainViewModel.FilterProducts();
            });

            CheckCategoryOther = new RelayCommand(obj =>
            {
                MainViewModel.Filters.Categories[2] = CategoryOther;

                MainViewModel.FilterProducts();
            });

            CheckInStock = new RelayCommand(obj =>
            {
                MainViewModel.Filters.InStockOnly = InStock;

                MainViewModel.FilterProducts();
            });
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
