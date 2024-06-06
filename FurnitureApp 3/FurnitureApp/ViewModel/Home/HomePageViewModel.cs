using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Model;
using FurnitureApp.Services;
using FurnitureApp.Views.Account;
using FurnitureApp.Views.Product;
using FurnitureApp.Views.ProductDetailsPagee;
using FurnitureApp.Views.Profile;
using Microsoft.Maui.ApplicationModel.Communication;
using static FurnitureApp.Model.ProductModel;

namespace FurnitureApp.ViewModel.Home
{
    public partial class HomePageViewModel : ObservableObject
    {
        #region Fields 
        private INavigation _navigation;
        #endregion 

        #region Ctor
        public HomePageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            setProducts();
            string storedEmailValue = Preferences.Get("email", defaultValue: string.Empty);
            UserName = storedEmailValue;
            getDataAsync();
            GetdataforExpand();
        }
        #endregion

        #region Commands
        [RelayCommand]
        private void IsProductGridOverlayVisible()
        {
            try
            {
                //IsProductListVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task ProductView(ProductModel productDatails)
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
        private async Task SelectCategory(CategoryModel category)
        {
            try
            {
                await _navigation.PushAsync(new ProductListView(category));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private void Menu()
        {
            try
            {
                IsMenuBarVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        [RelayCommand]
        private void CloseMenuBar()
        {
            try
            {
                IsMenuBarVisible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task Cart()
        {
            try
            {
                await _navigation.PushAsync(new CartPageView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task Profile()
        {
            try
            {
                await _navigation.PushAsync(new ProfileView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private async Task Address()
        {
            try
            {
                await _navigation.PushAsync(new AddressView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private async Task Orders()
        {
            try
            {
                await _navigation.PushAsync(new OrdersView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private async Task ProfileCart()
        {
            try
            {

                await _navigation.PushAsync(new CartPageView());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private async Task Contact()
        {
            try
            {

                await _navigation.PushAsync(new ContactView());
                //await _navigation.PushAsync(new ProfileView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [RelayCommand]
        private async Task Logout()
        {
            try
            {
                await _navigation.PushAsync(new LoginView());
                //await _navigation.PushAsync(new ProfileView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Private Methods
        public async Task getDataAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(SettingServices.Instance.UserId))
                {
                    var userResponse = await LoginServices.Instance.GetUserById();
                    if (userResponse != null && userResponse.User != null)
                    {

                        UserName = userResponse.User.FirstName + "" + userResponse.User.LastName;
                        ProfileImage = userResponse.User.ProfileImage.ImageUrl;
                        //SettingServices.Instance.UserName = userResponse.User.FirstName;
                        //    SettingServices.Instance.UserLastName = userResponse.User.LastName;
                        //    SettingServices.Instance.UserProfileImage = userResponse.User.ProfileImage.ImageUrl;
                        //    SettingServices.Instance.UserProfileImageThumbnail = userResponse.User.ProfileImage.ThumbnailUrl;
                        //    SettingServices.Instance.UserProfileImageFileName = userResponse.User.ProfileImageFileName;
                        //WeakReferenceMessenger.Default.Send(new RefreshUserInfo { Value = userResponse.User });

                        //await SaveLocalUser(userResponse.User); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void setProducts()
        {
            try
            {
                ProductList = new ObservableCollection<ProductModel>();
                ProductList.Add(new ProductModel { ProductUrl = "dinningwithsidetabel", ProductName = "Dinning Tabel With Side Table", ProductPrice = 100, ProductId = 1, ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support." });
                ProductList.Add(new ProductModel { CategoryId = 1, ProductId = 5, ProductUrl = "redmodernchair", ProductName = "Red Club Chair", ProductPrice = 75775, ProductDis = "The Red Club Chair is a bold and eye-catching seating option that commands attention with its vibrant and dynamic color. The rich red upholstery exudes energy and warmth, making it a standout piece in any room. " });
                ProductList.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchsix", ProductName = "White & Blue Couch With Table", ProductPrice = 78578, ProductDis = "The Modern Light White blue With Sleep is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                ProductList.Add(new ProductModel { CategoryId = 4, ProductId = 7, ProductUrl = "kidbed", ProductName = "kid Cortoon Bed", ProductPrice = 9554, ProductDis = "The Kid Cortoon Bedis a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                ProductList.Add(new ProductModel { ProductUrl = "brownes", ProductName = "Dinning Tabel With Side Table", ProductPrice = 100, ProductId = 1, ProductDis = "A chair typically consists of a seat, backrest, legs, and optional armrests. It comes in various styles and materials, serving different functions in settings like homes, offices, and public spaces. Modern chairs often prioritize ergonomic design for comfort and support." });
                ProductList.Add(new ProductModel { ProductUrl = "creambed", ProductName = "Stylish Bed King Size", ProductPrice = 100, ProductId = 2, ProductDis = "A sofa set is a collection of seating furniture typically comprising a larger main sofa and additional chairs or loveseats. Designed for comfort and style, sofa sets are common in living spaces and often feature coordinated upholstery and design elements." });
                ProductList.Add(new ProductModel { ProductUrl = "whitees", ProductName = "Modern Dinning", ProductPrice = 100, ProductId = 2, ProductDis = "A sofa set is a collection of seating furniture typically comprising a larger main sofa and additional chairs or loveseats. Designed for comfort and style, sofa sets are common in living spaces and often feature coordinated upholstery and design elements." });
                ProductList.Add(new ProductModel { ProductUrl = "peachclubchair", ProductName = "Peach Club Chair", ProductPrice = 100, ProductId = 2, ProductDis = "A sofa set is a collection of seating furniture typically comprising a larger main sofa and additional chairs or loveseats. Designed for comfort and style, sofa sets are common in living spaces and often feature coordinated upholstery and design elements." });


                var c1 = new ObservableCollection<ProductModel>();
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 5, ProductUrl = "redmodernchair", ProductName = "Red Club Chair", ProductPrice = 75775, ProductDis = "The Red Club Chair is a bold and eye-catching seating option that commands attention with its vibrant and dynamic color. The rich red upholstery exudes energy and warmth, making it a standout piece in any room. " });
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 5, ProductUrl = "yellowchair", ProductName = "Yellow Club Chair", ProductPrice = 25775, ProductDis = "The Yellow Club Chair is a cheerful and stylish seating option that brings a burst of sunshine to any room. Its vibrant yellow upholstery exudes positivity and adds a lively touch to the space. The club chair's design is both classic and inviting, featuring a comfortable seat and a sleek silhouette. " });
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 2, ProductUrl = "bottlegreenclubchair", ProductName = "Bottle Green Club Chair", ProductPrice = 8575, ProductDis = "The Bottle Green Club Chair is an elegant and sophisticated seating option that combines style and comfort. Featuring a rich bottle green upholstery, this club chair exudes a sense of luxury and classic charm. Its timeless design includes a plush, cushioned seat and backrest, providing a cozy and inviting place to relax.." });
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 3, ProductUrl = "peachclubchair", ProductName = "Peach Club Chair", ProductPrice = 785785, ProductDis = "The Peach Club Chair is a delightful and inviting seating option that effortlessly blends modern aesthetics with a touch of warmth. Adorned in a soft peach-colored upholstery, this club chair exudes a fresh and contemporary vibe. " });
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 4, ProductUrl = "classicchair", ProductName = "Club pink Chair", ProductPrice = 22275, ProductDis = "The Peach Club Pink Chair is a charming fusion of elegance and contemporary flair. Its soft pink hue, reminiscent of a peach's delicate blush, brings a touch of femininity and sophistication to any space. The chair's modern design features clean lines and a sleek silhouette, creating a stylish focal point in a room. " });
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 5, ProductUrl = "whitechair", ProductName = "Classic White Chair", ProductPrice = 75775, ProductDis = "The Classic White Chair is a timeless and versatile piece that radiates simplicity and elegance. With its clean lines and crisp white upholstery, this chair effortlessly complements any interior style, from traditional to modern." });
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 1, ProductUrl = "blueclubchair", ProductName = "Blue Club Chair", ProductPrice = 57585, ProductDis = "A sofa set is a collection of seating furniture typically comprising a larger main sofa and additional chairs or loveseats. Designed for comfort and style, sofa sets are common in living spaces and often feature coordinated upholstery and design elements." });
                c1.Add(new ProductModel { CategoryId = 1, ProductId = 5, ProductUrl = "clubchair", ProductName = "Classic Club Chair", ProductPrice = 9775, ProductDis = "The Classic Club Chair is a timeless and refined seating option that exudes sophistication and charm. With its elegant design and traditional silhouette, this chair offers a touch of understated luxury to any space. " });


                var c2 = new ObservableCollection<ProductModel>();
                c2.Add(new ProductModel { CategoryId = 2, ProductId = 5, ProductUrl = "cream", ProductName = "Cream color Couch", ProductPrice = 2557, ProductDis = "The Cream Couch a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c2.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "blue", ProductName = "Blue Couch", ProductPrice = 5525, ProductDis = "TheBlue Couch spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c2.Add(new ProductModel { CategoryId = 2, ProductId = 3, ProductUrl = "bluecouch", ProductName = "Blue Couch New", ProductPrice = 5875, ProductDis = "The Blue Couch new spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c2.Add(new ProductModel { CategoryId = 2, ProductId = 4, ProductUrl = "couch", ProductName = "Lite Orange Couch ", ProductPrice = 552, ProductDis = "The Lite Orange Couch a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c2.Add(new ProductModel { CategoryId = 2, ProductId = 5, ProductUrl = "graycaouch", ProductName = "Blackish color Couch", ProductPrice = 78578, ProductDis = "The Cream Coucha contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c2.Add(new ProductModel { CategoryId = 2, ProductId = 1, ProductUrl = "blackcouch", ProductName = "Black Couch", ProductPrice = 7584, ProductDis = "The Black Couchis a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });

                var c3 = new ObservableCollection<ProductModel>();
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 1, ProductUrl = "blackfs", ProductName = "Black Dinning", ProductPrice = 74842, ProductDis = "Black Dinning 4 Chairs is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 2, ProductUrl = "brownes", ProductName = "Brown Dinning with 8 Chair", ProductPrice = 36472, ProductDis = "The Brown Dining Set with 8 Chairs is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 3, ProductUrl = "brownssdinning", ProductName = "Creamy Dinning with 8 Chair", ProductPrice = 78585, ProductDis = "Creamy Dinning with with 8 Chairs is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 4, ProductUrl = "chocolatefs", ProductName = "Choclate Dinning with 2 Chair", ProductPrice = 1452, ProductDis = "Choclate Dinning with 2 Chair is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 5, ProductUrl = "dinningwithsidetabel", ProductName = "Choclate Dinning Ronded Chair", ProductPrice = 5252, ProductDis = "Choclate Dinning Ronded Chair is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 6, ProductUrl = "pngwingcom", ProductName = "4P Dinning with Chair", ProductPrice = 28584, ProductDis = "4P Dinning with Chair is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 7, ProductUrl = "roundtabledinning", ProductName = "Classic Dinning ", ProductPrice = 75877, ProductDis = "Classic Dinning with 4 Chairs is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 8, ProductUrl = "whitees", ProductName = "Modern Dinning", ProductPrice = 5253, ProductDis = "The Modern Dinning Set with 8 Chairs is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });
                c3.Add(new ProductModel { CategoryId = 3, ProductId = 9, ProductUrl = "whit", ProductName = "Modern Dinning Black Color", ProductPrice = 4528, ProductDis = "The Modern Dinning Black ColorSet with 8 Chairs is a sophisticated and spacious ensemble designed for elegant dining experiences. Featuring a rich brown finish, the table and chairs exude warmth and classic charm. The expansive tabletop provides ample space for gatherings, while the eight matching chairs offer comfort and style. " });

                var c4 = new ObservableCollection<ProductModel>();
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 1, ProductUrl = "bbb", ProductName = "Brown Bed King Size", ProductPrice = 74500, ProductDis = "The Brown King Size Bed is a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 2, ProductUrl = "beddd", ProductName = "Grey Bed King Size", ProductPrice = 14263, ProductDis = "The ProductDis= \"The Brown King Size Bed is a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. \" Bed is a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 3, ProductUrl = "blackbed", ProductName = "Modern Bed King Size", ProductPrice = 41525, ProductDis = "The Modern Bed King Size Bed is a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 4, ProductUrl = "creambed", ProductName = "Stylish Bed King Size", ProductPrice = 74841, ProductDis = "The Stylish Bed King Sizeis a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 5, ProductUrl = "greenshadebed", ProductName = "Green Color King Size", ProductPrice = 84762, ProductDis = "The Green Color King SizeBed is a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 7, ProductUrl = "kidbed", ProductName = "kid Cortoon Bed", ProductPrice = 9554, ProductDis = "The Kid Cortoon Bedis a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 6, ProductUrl = "woodenbody", ProductName = "Old Bed 1990", ProductPrice = 78584, ProductDis = "The Old Bed 1990 Bed is a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });
                c4.Add(new ProductModel { CategoryId = 4, ProductId = 7, ProductUrl = "woodenbodybed", ProductName = "Flate Bed OldStyle", ProductPrice = 6254, ProductDis = "The Flate Bed OldStyleBed is a luxurious and inviting centerpiece for any bedroom. With its rich brown finish, this bed exudes warmth and elegance. The king-size dimensions provide ample space for a comfortable night's sleep, while the bed's design combines classic elements with a modern touch. " });

                var c5 = new ObservableCollection<ProductModel>();
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchone", ProductName = "Modern 8P Family Couch", ProductPrice = 78578, ProductDis = "The Modern 8P Family Couch is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchtwo", ProductName = "White 4P Family Couch", ProductPrice = 78578, ProductDis = "The Modern 4P Family Couch is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchthree", ProductName = "Black 2P  Couch", ProductPrice = 78578, ProductDis = "The Modern 2P Family Couch is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchfour", ProductName = "Light White With Sleep Couch", ProductPrice = 78578, ProductDis = "The Modern Light White With Sleep is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchfive", ProductName = "Family Couch  5P With Table", ProductPrice = 78578, ProductDis = "The Modern Light White With Sleep is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchsix", ProductName = "White & Blue Couch With Table", ProductPrice = 78578, ProductDis = "The Modern Light White blue With Sleep is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "couchseven", ProductName = "White ModernCouch ", ProductPrice = 78578, ProductDis = "The Modern Light White blue With Sleep is a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });
                c5.Add(new ProductModel { CategoryId = 2, ProductId = 2, ProductUrl = "coucheight", ProductName = "Blue Modern Couch", ProductPrice = 78578, ProductDis = "The Modern Blueis a contemporary and spacious seating solution designed for both style and comfort. With seating for up to eight people, this couch is ideal for family gatherings and entertaining guests. Its modern design incorporates clean lines, a streamlined silhouette, and versatile upholstery, making it a chic addition to any living space. " });


                CategoryList = new ObservableCollection<CategoryModel>();
                CategoryList.Add(new CategoryModel { Id = 1, ProductImageUrl = "yellowchair", CategoryName = "Club Chairs", ProductList = c1.ToList() });
                CategoryList.Add(new CategoryModel { Id = 2, ProductImageUrl = "couchone", CategoryName = "Modern Style Couch", ProductList = c5.ToList() });
                CategoryList.Add(new CategoryModel { Id = 3, ProductImageUrl = "whitees", CategoryName = "Dinning Set", ProductList = c3.ToList() });
                CategoryList.Add(new CategoryModel { Id = 4, ProductImageUrl = "bbb", CategoryName = "Bed", ProductList = c4.ToList() });
                CategoryList.Add(new CategoryModel { Id = 5, ProductImageUrl = "multicolorcouch", CategoryName = "Simple Classic Couch", ProductList = c2.ToList() });



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetdataforExpand()
        {
            MyPropertyItems = new ObservableCollection<PropertyItem>
             {
                new PropertyItem(){Header = "Category", MyPropertyItems = new List<PropertyItemDetails>{ new PropertyItemDetails { CategoryName="Club Chairs" } ,
                    new PropertyItemDetails { CategoryName = "Modern Style Couch" } ,
                    new PropertyItemDetails { CategoryName = "Dinning Set" } ,
                    new PropertyItemDetails { CategoryName="Bed"},
                    new PropertyItemDetails { CategoryName="Simple Classic Couch"}
                } },
                new PropertyItem(){Header = "All Products", MyPropertyItems = new List<PropertyItemDetails>{ new PropertyItemDetails { CategoryName="Comming Soon"} } },
            };
        }

        ObservableCollection<PropertyItem> myPropertyItems;
        public ObservableCollection<PropertyItem> MyPropertyItems
        {
            get { return myPropertyItems; }
            set
            {
                myPropertyItems = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Binding Properties
        [ObservableProperty]
        private bool _isProductListVisible = false;

        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        public static string _profileImage;

        public ObservableCollection<CategoryModel> categoryList = new ObservableCollection<CategoryModel>();
        public ObservableCollection<CategoryModel> CategoryList
        {
            get => categoryList;
            set
            {
                categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
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
        public class UserNameKey
        {
            public static string UserName = "Bharat@12";

        }

        private bool _isMenuBarVisible;
        public bool IsMenuBarVisible
        {
            get => _isMenuBarVisible;
            set
            {
                _isMenuBarVisible = value;
                OnPropertyChanged(nameof(IsMenuBarVisible));

            }
        }
        #endregion
    }
}

