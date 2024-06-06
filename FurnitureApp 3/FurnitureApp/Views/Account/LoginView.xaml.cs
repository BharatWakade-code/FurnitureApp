using FurnitureApp.ViewModel.Account;
using Microsoft.Maui.ApplicationModel.Communication;

namespace FurnitureApp.Views.Account;

public partial class LoginView : ContentPage
{
  
    public LoginView()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
      
    }

    void EmailEntry_Completed(System.Object sender, System.EventArgs e)
    {
        passwordEntry.Focus();
    }
}
