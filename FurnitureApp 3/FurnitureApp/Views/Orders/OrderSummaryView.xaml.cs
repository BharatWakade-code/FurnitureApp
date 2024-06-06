using FurnitureApp.ViewModel.Orders;

namespace FurnitureApp.Views.Orders;

public partial class OrderSummaryView : ContentPage
{
  
    public OrderSummaryView()
	{
		InitializeComponent();
        BindingContext = new OrderSummaryViewModel(Navigation);

    }
  
}
