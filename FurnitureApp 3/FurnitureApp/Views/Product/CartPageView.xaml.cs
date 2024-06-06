using FurnitureApp.Model;
using FurnitureApp.ViewModel.Product;

namespace FurnitureApp.Views.Product;

public partial class CartPageView : ContentPage
{
	public CartPageView( )
	{
        InitializeComponent();
        BindingContext = new CartPageViewModel(Navigation); 
    } 
}
