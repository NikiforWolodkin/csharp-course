using Lab_4.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public RelayCommand NextPage { get; set; }
        public RelayCommand PreviousPage { get; set; }

        public ProductViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            Page = "1";
            SelectedProducts = mainViewModel.FilteredProducts.Take(6).ToList();

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
        }

        private void UpdateProducts()
        {
            
        }
    }
}
