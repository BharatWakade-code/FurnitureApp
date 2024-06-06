using FurnitureApp.Handlers;
using FurnitureApp.Views.Account;
using FurnitureApp.Views.Home;

namespace FurnitureApp;

public partial class App : Application
{

    // public static string AppUserName;
    public App()
    {
        string storedEmailValue = Preferences.Get("email", defaultValue: string.Empty);
        //string storedPassValue = Preferences.Get("StoredPassword", defaultValue: string.Empty);

        InitializeComponent();
        //CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        //var token =  CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        //Console.WriteLine($"FCM token : {token}");

        if (string.IsNullOrEmpty(storedEmailValue))
        {

            MainPage = new NavigationPage(new LoginView());
        }
        else
        {
            MainPage = new NavigationPage(new HomePageView());
        }
        SetHandlers();


    }
    protected override void OnStart()
    {
        base.OnStart();
    }
    private void SetHandlers()    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
#if __ANDROID__
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            handler.PlatformView.SetPadding(0, 0, 0, 0);
            handler.PlatformView.SetIncludeFontPadding(false);
#elif __IOS__
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif

        });

    }
}

