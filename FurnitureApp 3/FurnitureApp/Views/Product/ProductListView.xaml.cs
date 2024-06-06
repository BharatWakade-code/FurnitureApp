using FurnitureApp.Model;
using FurnitureApp.ViewModel.Product;

namespace FurnitureApp.Views.Product;

public partial class ProductListView : ContentPage
{
	public ProductListView(CategoryModel category)
	{
		InitializeComponent();
        BindingContext = new ProductListViewModel(Navigation, category);
    }
}
