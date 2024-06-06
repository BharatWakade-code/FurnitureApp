using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Model;

namespace FurnitureApp.ViewModel.Orders
{
	public partial class OrderDetailsPageViewModel : ObservableObject
    {
        #region Fields  
        private INavigation _navigation;
        #endregion

        #region ctor

        public OrderDetailsPageViewModel(INavigation navigation, ProductModel productModel)
		{
            _navigation = navigation;
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
        #endregion

    }
}

