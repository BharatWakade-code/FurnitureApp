using FurnitureApp.Model;
using FurnitureApp.ViewModel.Orders;

namespace FurnitureApp.Views.Orders;

public partial class OrderDetailsPageView : ContentPage
{
  

    public OrderDetailsPageView(ProductModel ProductModel)
	{
		InitializeComponent();
        BindingContext = new OrderDetailsPageViewModel(Navigation, ProductModel);

    }
}
