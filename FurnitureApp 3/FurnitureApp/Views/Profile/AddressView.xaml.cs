using FurnitureApp.ViewModel.Profile;

namespace FurnitureApp.Views.Profile;

public partial class AddressView : ContentPage
{
	public AddressView()
	{
		InitializeComponent();
        BindingContext = new AddressViewModel(Navigation);
    }
}
