using FurnitureApp.Model;
using FurnitureApp.ViewModel.Profile;

namespace FurnitureApp.Views.Profile;

public partial class OrdersView : ContentPage
{
	public OrdersView()
	{
		InitializeComponent();
        BindingContext = new OrdersViewModel(Navigation);
    }
}
