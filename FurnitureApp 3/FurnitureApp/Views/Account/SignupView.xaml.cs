using FurnitureApp.ViewModel.Account;

namespace FurnitureApp.Views.Account;

public partial class SignupView : ContentPage
{
	public SignupView()
	{
		InitializeComponent(); 
		BindingContext = new SignupViewModel(Navigation);
	}
}
