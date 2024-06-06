using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Model;
using FurnitureApp.Views.Product;
using static FurnitureApp.ViewModel.Home.HomePageViewModel;

namespace FurnitureApp.ViewModel.ProductDetails
{
    public partial class ProductDetailsPageViewModel : ObservableObject
    {
        #region Fields  
        private INavigation _navigation;
        ProductModel _productByCategory1;
        #endregion

        #region ctor

        public ProductDetailsPageViewModel(INavigation navigation , ProductModel  productModel)
        {
            _navigation = navigation;
            _productByCategory1 = productModel;
             getHorizontalProductList();
             getDataFromCategory(productModel);
             getDataFromHomeModel(productModel);
             getDataFromCart(productModel);
       
            string storedEmailValue = Preferences.Get(UserNameKey.UserName, defaultValue: string.Empty);
            UserName = storedEmailValue;

        }

        #endregion

        #region Commands
        
        [RelayCommand]
        private void minus()
        {
            try
            {
                var i = ProductCount;
                i--;
                ProductCount = i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private void  plus()
        {
            try
            {
                var i = ProductCount;
                i++;
                ProductCount = i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private async Task AddtoCart()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert(UserName, "Product Added  Succesfully ", "OK");
                await _navigation.PushAsync(new CartPageView());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task BackArrow()
        {
            try
            {
                await _navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        #endregion

        #region Private Methods 

        private void getHorizontalProductList()
        {
            try
            {
                SimilarProductList = new ObservableCollection<ProductModel>();
                SimilarProductList.Add(new ProductModel { ProductName = "White Club Chair", });
                SimilarProductList.Add(new ProductModel { ProductName = "Sofa Set", });
                SimilarProductList.Add(new ProductModel { ProductName = "Couch", });
                SimilarProductList.Add(new ProductModel { ProductName = "Dinning Set For 8P", });
                SimilarProductList.Add(new ProductModel { ProductName = "King Size Bed", });
                SimilarProductList.Add(new ProductModel { ProductName = "Classic Chair", });

                ProductList = new ObservableCollection<ProductModel>();
                ProductList.Add(new ProductModel { ProductUrl = "green", ProductName = "White Club Chair", ProductPrice = 100, ProductId = 1 });
                ProductList.Add(new ProductModel { ProductUrl = "multicolorcouch", ProductName = "Sofa Set", ProductPrice = 100, ProductId = 2 });
                ProductList.Add(new ProductModel { ProductUrl = "bluecouch", ProductName = "Couch", ProductPrice = 100, ProductId = 3 });
                ProductList.Add(new ProductModel { ProductUrl = "green", ProductName = "Dining", ProductPrice = 100, ProductId = 4 });
                ProductList.Add(new ProductModel { ProductUrl = "greenshadebed", ProductName = "Green Bed", ProductPrice = 100, ProductId = 5 });
                ProductList.Add(new ProductModel { ProductUrl = "bluecouch", ProductName = "Couch", ProductPrice = 100, ProductId = 6 });

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void getDataFromHomeModel(ProductModel productModel)
        {
            try
            {
                ProductName = productModel.ProductName;
                ProductUrl = productModel.ProductUrl;
                ProductDis = productModel.ProductDis;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void getDataFromCart(ProductModel productModel)
        {
            try
            {
                ProductName = productModel.ProductName;
                ProductUrl = productModel.ProductUrl;
                ProductCount = productModel.ProductQuantity;
               ProductDis = productModel.ProductDis;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void getDataFromCategory(ProductModel productByCategory)
        {
            try
            {
                if(productByCategory != null)
                {
                    ProductName = productByCategory.CategoryName;
                    //ProductUrl = productByCategory.ProductImageUrl;
                    ProductCount = productByCategory.ProductQuantity;
                    ProductDis = productByCategory.ProductDis;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        #endregion

        #region Binding Properties
        [ObservableProperty]
        private bool _isProductListVisible=false;

        [ObservableProperty]
        private int _productCount;

        [ObservableProperty]
        private string _productName;

        [ObservableProperty]
        private ImageSource _productUrl;

        [ObservableProperty]
        private ImageSource _productDis;

        [ObservableProperty]
        private string _userName;

        public ObservableCollection<ProductModel> similarProductList = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> SimilarProductList
        {
            get => similarProductList;
            set
            {
                similarProductList = value;
                OnPropertyChanged(nameof(SimilarProductList));
            }
        }

        public ObservableCollection<ProductModel> productList = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> ProductList
        {
            get => productList;
            set
            {
                productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

       
        //private ProductModel ProductModel;


        #endregion
    }
}

