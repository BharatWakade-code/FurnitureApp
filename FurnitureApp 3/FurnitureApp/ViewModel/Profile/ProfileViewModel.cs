using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Services;

namespace FurnitureApp.ViewModel.Profile
{
    public partial class ProfileViewModel : ObservableObject
    {

        #region Fields 
        private INavigation _navigation;

        public string ImageFilePath;
        public byte[] ByteInPicture;
        public byte[] ByteInThumbPicture;
        private string token;


        #endregion

        #region Ctor
        public ProfileViewModel(INavigation navigation)
        {
            _navigation = navigation;
            token = Preferences.Get("token", defaultValue: string.Empty);
            _profileImage = Preferences.Get("image", defaultValue: string.Empty);
            getDataAsync();
            //getEditDataAsync();
            //getData();
            //string storedUserNameValue = Preferences.Get("Firstname", defaultValue: string.Empty);
            //UserName = SettingServices.Instance.UserFirstName;
            //string storedFullNameValue = Preferences.Get("fullname", defaultValue: string.Empty);
            //FullName = storedFullNameValue;
            //string storedEmailValue = Preferences.Get("email", defaultValue: string.Empty);
            //Email = storedEmailValue;
        }
        #endregion

        #region Command
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
        private async Task TakePhoto(Object obj)
        {
            try
            {

                string action = await App.Current.MainPage.DisplayActionSheet("Select an Option", "Cancel", null, "Take Photo", "Pick Photo");

                if (action == "Take Photo")
                {
                    await App.Current.MainPage.DisplayAlert("Coming Soon", "This feature is currently under development. Stay tuned!", "OK");
                }
                else if (action == "Pick Photo")
                {
                    if (MediaPicker.Default.IsCaptureSupported)
                    {
                        FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions { Title = "Select Your Image" });
                        try
                        {
                            if (photo != null)
                            {
                                var stream = await photo.OpenReadAsync();
                                ProfileImage = ImageSource.FromStream(() => stream);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion

        #region Private methods
        public async Task getDataAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(SettingServices.Instance.UserId))
                {
                    var userResponse = await LoginServices.Instance.GetUserById();
                    if (userResponse != null && userResponse.User != null)
                    {

                        UserName = userResponse.User.FirstName;
                        FullName = userResponse.User.FirstName;
                        Phone = userResponse.User.PhoneNumber;
                        Email = userResponse.User.Email;
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

        #endregion

        #region Binding Properties

        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _fullName;
        [ObservableProperty]
        private string _phone;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _address;
        [ObservableProperty]
        public static ImageSource _profileImage;
        #endregion

    }

}
