using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Model;
using FurnitureApp.Views.Orders;

namespace FurnitureApp.ViewModel.Orders
{
	public partial class  OrderSummaryViewModel : ObservableObject
    {
        #region Fields  
        private INavigation _navigation;
        #endregion

        #region ctr
        public OrderSummaryViewModel(INavigation navigation)
		{
            _navigation = navigation;
            getOrdersList();
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

        [RelayCommand]
        private async Task NavigateToPayment()
        {
            try
            {
                await _navigation.PushAsync(new PaymentPageView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Private Methods
        public void getOrdersList()
        {
            try
            {
                OrderProductList = new ObservableCollection<ProductModel>();
                OrderProductList.Add(new ProductModel { ProductId = 1 ,ProductUrl = "green", ProductName = "White Club Chair", ProductPrice = 100,  ProductMRP=800 , ProductOffers=20});
                OrderProductList.Add(new ProductModel { ProductId = 2 ,ProductUrl = "multicolorcouch", ProductName = "Sofa Set", ProductPrice = 400, ProductMRP = 800, ProductOffers=50 });
                OrderProductList.Add(new ProductModel { ProductId = 3 ,ProductUrl = "green", ProductName = "White Club Chair", ProductPrice = 17200, ProductMRP = 72800 ,ProductOffers =80});
               

            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
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

