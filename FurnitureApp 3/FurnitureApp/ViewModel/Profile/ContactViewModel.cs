using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Views.Home;

namespace FurnitureApp.ViewModel.Profile
{
    public partial class ContactViewModel : ObservableObject
    {
        #region Fields 
        private INavigation _navigation;
        #endregion
        #region Ctor
        public ContactViewModel(INavigation navigation)
        {
            _navigation = navigation;
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

        #endregion
    }
}

