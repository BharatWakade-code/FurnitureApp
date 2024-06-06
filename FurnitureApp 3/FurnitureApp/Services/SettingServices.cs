using System;
namespace FurnitureApp.Services
{
    public class SettingServices
    {

        #region Fields

        static SettingServices _instance;

        #endregion

        #region Ctor

        public SettingServices()
        {
        }
        public static SettingServices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingServices();

                return _instance;
            }
        }

        #endregion

        #region Setting Constants

        private const string userId = "UserId";
        private const string Username = "UserName";
        private const string accessToken = "access_token";
        private const string userFullName = "FullName";
        private const string userEmail = "UserEmail";
        private const string userFirstName = "UserFirstName";
        private const string userLastName = "UserLastName";
        private const string userProfileImage = "UserProfileImage";
        private const string userProfileImageThumbnail = "UserProfileImageThumbnail";
        private const string userProfileImageFileName = "UserProfileImageFileName ";
        private const string fcmToken = "FCMToken";
        private const string accountOnboardingCompleted = "AccountOnboardingCompleted";
        #endregion

        #region Settings Properties

        public string UserId
        {
            get => Preferences.Get(userId, string.Empty);
            set => Preferences.Set(userId, value);
        }
        public string AccessToken
        {
            get => Preferences.Get(accessToken, string.Empty);
            set => Preferences.Set(accessToken, value);
        }
        public string UserName
        {
            get => Preferences.Get(Username, string.Empty);
            set => Preferences.Set(Username, value);
        }
        public string FullName
        {
            get => Preferences.Get(userFullName, string.Empty);
            set => Preferences.Set(userFullName, value);
        }

        public string UserEmail
        {
            get => Preferences.Get(userEmail, string.Empty);
            set => Preferences.Set(userEmail, value);
        }

        public string UserFirstName
        {
            get => Preferences.Get(userFirstName, string.Empty);
            set => Preferences.Set(userFirstName, value);
        }

        public string UserLastName
        {
            get => Preferences.Get(userLastName, string.Empty);
            set => Preferences.Set(userLastName, value);
        }

        public string UserProfileImage
        {
            get => Preferences.Get(userProfileImage, string.Empty);
            set => Preferences.Set(userProfileImage, value);
        }
        public string UserProfileImageFileName
        {
            get => Preferences.Get(userProfileImageFileName, string.Empty);
            set => Preferences.Set(userProfileImageFileName, value);
        }

        public string UserProfileImageThumbnail
        {
            get => Preferences.Get(userProfileImageThumbnail, string.Empty);
            set => Preferences.Set(userProfileImageThumbnail, value);
        }
        public string FCMToken
        {
            get => Preferences.Get(fcmToken, string.Empty);
            set => Preferences.Set(fcmToken, value);
        }
        public string AccountOnboardingCompleted
        {
            get => Preferences.Get(accountOnboardingCompleted, string.Empty);
            set => Preferences.Set(accountOnboardingCompleted, value);
        }

        #endregion
    }
}

