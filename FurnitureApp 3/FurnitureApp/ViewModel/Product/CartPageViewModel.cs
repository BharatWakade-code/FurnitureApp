using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using FurnitureApp.Model;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Views.Home;
using FurnitureApp.Views.Profile;
using System.ComponentModel;
using FurnitureApp.Views.ProductDetailsPagee;
using FurnitureApp.Views.Orders;

namespace FurnitureApp.ViewModel.Product
{
    public partial class CartPageViewModel : ObservableObject
    {

        #region Fields  
        private INavigation _navigation;

        #endregion

        #region Ctor 
        public CartPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            getCartProductsList();
            //getCartDetails(cartDetails);
            //  GetProductModels();

        }
        #endregion

        #region Commands

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
        [RelayCommand]
        private async Task Delete(ProductModel productModel)
        {
            try
            {
                // Assuming ProductModel has a property called ProductId
                var itemToRemove = CartProductList.FirstOrDefault(item => item.ProductId == productModel.ProductId);

                if (itemToRemove != null)
                {
                    CartProductList.Remove(itemToRemove);
                    await App.Current.MainPage.DisplayAlert("", "Delete Successfully", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Item not found", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private  void Clear()
        {
            try
            {
                removeCartProductList(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private Task PlusTap(ProductModel productCount)
        {
            try
            {
                var i = productCount.ProductQuantity;
                i++;
                productCount.ProductQuantity = i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Task.CompletedTask;
        }

        [RelayCommand]
        private Task MinusTap(ProductModel productCount)
        {
            try
            {

                var i = productCount.ProductQuantity;
                i--;
                if (i < 1)
                {
                    return Task.CompletedTask;
                }

                productCount.ProductQuantity = i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Task.CompletedTask;
        }


        [RelayCommand]
        private async Task TodetailsPage(ProductModel productDatails)
        {
            try
            {
                await _navigation.PushAsync(new ProductDetailsPageView(productDatails));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        [RelayCommand]
        private async Task NavtoOrderSummary()
        {
            try
            {
                await _navigation.PushAsync(new OrderSummaryView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }


        #endregion

        #region Uitility
        #endregion

        #region Private Methods
        private void removeCartProductList()
        {
            try
            {

                CartProductList = new ObservableCollection<ProductModel>();

                CartProductList.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void getCartProductsList()
        {
            try
            {

                CartProductList = new ObservableCollection<ProductModel>();
                CartProductList.Add(

                    new ProductModel
                    {
                        ProductId = 1,
                        ProductUrl = "creamcolor",
                        ProductName = "White Club Chair ",
                        ProductPrice = 3456,
                        ProductQuantity = 5,
                        ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support."

                    }
                );

                cartProductList.Add(

                      new ProductModel
                      {
                          ProductId = 2,
                          ProductUrl = "green",
                          ProductName = "Green Chair",
                          ProductPrice = 7004,
                          ProductQuantity = 5,
                          ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support."


                      }
                    );
                cartProductList.Add(
                     new ProductModel
                     {

                         ProductId = 3,
                         ProductUrl = "greenshadebed",
                         ProductName = "Green Bed",
                         ProductPrice = 24700,
                         ProductQuantity = 5,
                         ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support."

                     }
                   );
                cartProductList.Add(
                      new ProductModel
                      {
                          ProductId = 4,
                          ProductUrl = "multicolorcouch",
                          ProductName = "Multi Colour Couch",
                          ProductPrice = 7004,
                          ProductQuantity = 5,
                          ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support."

                      }
                    );
                cartProductList.Add(
                      new ProductModel
                      {
                          ProductId = 5,
                          ProductUrl = "creambed",
                          ProductName = "Classic Bed",
                          ProductPrice = 7004,
                          ProductQuantity = 7,
                          ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support."

                      }
                    );
                
                  
                cartProductList.Add(
                     new ProductModel
                     {
                         ProductId = 7,
                         ProductUrl = "greencouchst",
                         ProductQuantity = 8,
                         ProductName = "Green Couch",
                         ProductPrice = 7004,
                         ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support."


                     }
                   );
             

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Binding Properties

        [ObservableProperty]
        private string _productName;

        [ObservableProperty]
        private ImageSource _productUrl;

        public ObservableCollection<ProductModel> cartProductList = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> CartProductList
        {
            get => cartProductList;
            set
            {
                cartProductList = value;
                OnPropertyChanged(nameof(CartProductList));
            }
        }


        #endregion
    }

}

