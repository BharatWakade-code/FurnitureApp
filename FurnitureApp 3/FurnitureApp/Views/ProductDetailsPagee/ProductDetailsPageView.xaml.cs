using FurnitureApp.Model;
using FurnitureApp.ViewModel.ProductDetails;
namespace FurnitureApp.Views.ProductDetailsPagee;

public partial class ProductDetailsPageView : ContentPage
{ 

    public ProductDetailsPageView(ProductModel productModel)
	{
		InitializeComponent();
		BindingContext = new ProductDetailsPageViewModel(Navigation ,productModel);
	}
}
