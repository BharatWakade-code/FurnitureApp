using FurnitureApp.ViewModel.Home;

namespace FurnitureApp.Views.Home;

public partial class HomePageView : ContentPage
{
    public HomePageView()
    {
        InitializeComponent();
        BindingContext = new HomePageViewModel(Navigation);
    }

    //async void TopManu_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    //{

    //    GridOverLay.IsVisible = true;
    //    await GridOverLay.TranslateTo(0, 0, 400, Easing.Linear);

    //}

    //async void Box_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    //{
    //    await GridOverLay.TranslateTo(-250, 0, 400, Easing.Linear);

    //    GridOverLay.IsVisible = false;
    //}
}
