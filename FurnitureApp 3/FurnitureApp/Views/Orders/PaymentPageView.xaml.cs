using FurnitureApp.ViewModel.Orders;

namespace FurnitureApp.Views.Orders;

public partial class PaymentPageView : ContentPage
{
    private string _deviceToken;
    public PaymentPageView()
	{
        InitializeComponent();
        BindingContext = new PaymentPageViewModel(Navigation);
    }

}
