using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Model;
using FurnitureApp.Services;
using FurnitureApp.Views.Account;
using FurnitureApp.Views.Home;
using Newtonsoft.Json;
using Plugin.Firebase.CloudMessaging;
using static FurnitureApp.Model.ApiModel;

namespace FurnitureApp.ViewModel.Account
{
    public partial class LoginViewModel : ObservableObject
    {

        #region Fields 
        private INavigation _navigation;
        private string token;
        #endregion

        #region Ctor
        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            token = Preferences.Get("token", defaultValue: string.Empty);
        }

        #endregion

        #region Commands

        [RelayCommand]
        private async Task Login()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email))
                {
                    IsEmailErrorMesgVisible = true;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    IsPassErrorMesgVisible = true;
                }
                else
                {

                    var endpoint = Model.GlobalUrl.BaseUrl + GlobalUrl.Signin;

                    var newpost = new LoginRequestModel()
                    {
                        Email = Email,
                        Password = Password,
                        PlatformId = 0,
                        TimeZone = null,
                        DeviceToken = null,
                        AppThemeId = 0,
                        DeviceId = null

                    };

                    var root = await LoginServices.Post(newpost, endpoint);

                    if (root.IsSuccess)
                    {
                        IsEmailErrorMesgVisible = false;
                        IsPassErrorMesgVisible = false;
                        if (root.Response != null)
                        {
                            LoginResponseModel responseModel = JsonConvert.DeserializeObject<LoginResponseModel>(root.Response.ToString());
                            if (responseModel != null)
                            {
                                Preferences.Set("email", responseModel.User?.Email);
                                SettingServices.Instance.UserId = responseModel.User.Id;
                                SettingServices.Instance.AccessToken = responseModel.Token.AccessToken;
                                SettingServices.Instance.UserEmail = responseModel.User.Email;
                                
                                await _navigation.PushAsync(new HomePageView());
                                await App.Current.MainPage.DisplayAlert("", "Login Successful", "OK");
                            }
                         
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("", "Login Fail", "OK");
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("", "Login Fail", "OK");

                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        [RelayCommand]
        private async Task SignUp()
        {
            try
            {
              
                await _navigation.PushAsync(new SignupView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }



        #endregion

        #region Utility

        #endregion

        #region Private Methods


        #endregion

        #region Binding Properties

        [ObservableProperty]
        private bool _isEmailErrorMesgVisible;

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                SetProperty(ref _email, value);

                if (!string.IsNullOrWhiteSpace(Email))
                    IsEmailErrorMesgVisible = false;
                else
                    IsEmailErrorMesgVisible = true;
            }
        }

        [ObservableProperty]
        private bool _isPassErrorMesgVisible;

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                SetProperty(ref _password, value);

                if (!string.IsNullOrWhiteSpace(Password))
                    IsPassErrorMesgVisible = false;
                else
                    IsPassErrorMesgVisible = true;
            }
        }


        #endregion
    }

}

