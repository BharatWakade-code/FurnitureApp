using FurnitureApp.ViewModel.Profile;

namespace FurnitureApp.Views.Profile;

public partial class ContactView : ContentPage
{
	public ContactView()
	{
		InitializeComponent();
        BindingContext = new ContactViewModel(Navigation);

    }
}
