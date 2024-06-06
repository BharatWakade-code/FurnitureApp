using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Views.Home;

namespace FurnitureApp.ViewModel.Profile
{
    public partial class AddressViewModel : ObservableObject
    {
        #region Fields 
        private INavigation _navigation;
        private string defaultadd = "At. Gadchiroli , Tah+Dist -Gadchiroli ";
        #endregion

        #region Ctor
        public AddressViewModel(INavigation navigation)
        {
            _navigation = navigation;
            EditAddress = Preferences.Get("add", defaultValue: defaultadd);

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
        private async Task Edit()
        {
            try
            {
                EditAddress = await App.Current.MainPage.DisplayPromptAsync("", "Add New Address",  "Add");
                Preferences.Set("add", EditAddress);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("", "Address Save Succesfully", "OK");
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion
        #region Binding Properties

        [ObservableProperty]
        private string _editAddress;
       
        #endregion
    }
}

