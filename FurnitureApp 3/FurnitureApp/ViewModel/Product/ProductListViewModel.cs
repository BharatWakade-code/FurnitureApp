using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using FurnitureApp.Model;
using FurnitureApp.Views.ProductDetailsPagee;

namespace FurnitureApp.ViewModel.Product
{
    public partial class ProductListViewModel : ObservableObject
    {
        #region Fields 
        private INavigation _navigation;
        CategoryModel _categoryl;

        #endregion

        #region Ctor
        public ProductListViewModel(INavigation navigation, CategoryModel categoryl)
        {
            _navigation = navigation;
            _categoryl = categoryl;
            CategoryName = categoryl.CategoryName;
            setProductList(categoryl);
        }
        #endregion

        #region Command
        [RelayCommand]
        private async Task BackArrow()
        {
            try
            {
                await _navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task ProductDetailsView(ProductModel productByCategory)
        {
            try
            {
                await _navigation.PushAsync(new ProductDetailsPageView(productByCategory));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Ptivate Methods
        private void setProductList(CategoryModel categoryId)
        {
            try
            {
                ProductList = new ObservableCollection<ProductModel>(categoryId.ProductList);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Binding Properties

        [ObservableProperty]
        private string _categoryName;

        //[ObservableProperty]
        //private int _productUrl;
        //[ObservableProperty]
        //private int _productName;
        //[ObservableProperty]
        //private int _productPrice;

        public ObservableCollection<ProductModel> _productList = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> ProductList
        {
            get => _productList;
            set
            {
                _productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        //[ObservableProperty]
        //private ObservableCollection<ProductByCategory> _productList = new ObservableCollection<ProductByCategory>();



        #endregion

    }
}

