using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Model;
using FurnitureApp.Views.Home;
using FurnitureApp.Views.Orders;

namespace FurnitureApp.ViewModel.Profile
{
	public partial class OrdersViewModel : ObservableObject
    {

        #region Fields 
        private INavigation _navigation;
        #endregion

        #region Ctor
        public OrdersViewModel(INavigation navigation)
        {
            _navigation = navigation;
            getOrderProductsList();
        }
        #endregion

        #region Commands
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
        private async Task ToOrderDetails(ProductModel ProductModel)
        {
            try
            {
                await _navigation.PushAsync( new OrderDetailsPageView(ProductModel));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task Delete(ProductModel productModel)
        {
            try
            {
                // Assuming ProductModel has a property called ProductId
                var itemToRemove = OrderProductList.FirstOrDefault(item => item.ProductId == productModel.ProductId);

                if (itemToRemove != null)
                {
                    OrderProductList.Remove(itemToRemove);
                    await App.Current.MainPage.DisplayAlert("", "Delete Successfully", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Item not found", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Private Methods

        private void getOrderProductsList()
        {
            try
            {

                OrderProductList = new ObservableCollection<ProductModel>();
                OrderProductList.Add(new ProductModel
                {
                    ProductId = 1,
                    ProductUrl = "creamcolor",
                    ProductName = "White Club Chair ",
                    ProductPrice = 3456,
                    ProductQuantity = 5,
                    ProductDate = "4/1/2024",

                }) ;
                OrderProductList.Add(new ProductModel
                {
                    ProductId = 1,
                    ProductUrl = "dinningwithsidetabel",
                    ProductName = "Dinning Tabel With Side Table ",
                    ProductPrice = 3456,
                    ProductQuantity = 1,
                    ProductDate = "4/4/2024",

                });
                OrderProductList.Add(new ProductModel
                {
                    ProductId = 1,
                    ProductUrl = "multicolorcouch",
                    ProductName = "Multi Colour Couch ",
                    ProductPrice = 3456,
                    ProductQuantity = 7,
                    ProductDate = "4/7/2024",

                }); OrderProductList.Add(new ProductModel
                {
                    ProductId = 1,
                    ProductUrl = "classicchair",
                    ProductName = "Classic Pink Chair",
                    ProductPrice = 3456,
                    ProductQuantity = 5,
                    ProductDate = "4/1/2024",

                }); 


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Binding Properties


        public ObservableCollection<ProductModel> orderProductList = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> OrderProductList
        {
            get => orderProductList;
            set
            {
                orderProductList = value;
                OnPropertyChanged(nameof(OrderProductList));
            }
        }


        #endregion
    }
}

