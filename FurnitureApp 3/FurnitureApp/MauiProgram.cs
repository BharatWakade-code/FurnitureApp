using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using Plugin.LocalNotification;
using The49.Maui.BottomSheet;
using Plugin.Firebase.Crashlytics;
using Plugin.Firebase.CloudMessaging;
#if IOS
using Plugin.Firebase.Bundled.Platforms.iOS;
#else
using Plugin.Firebase.Bundled.Platforms.Android;
#endif


namespace FurnitureApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseBottomSheet()
            .UseLocalNotification()
         //   .RegisterFirebaseServices()
            .ConfigureMauiHandlers(_ =>            {                LabelHandler.Mapper.AppendToMapping(                    nameof(View.BackgroundColor),                    (handler, View) => handler.UpdateValue(nameof(IView.Background)));                ButtonHandler.Mapper.AppendToMapping(                    nameof(View.BackgroundColor),                    (handler, View) => handler.UpdateValue(nameof(IView.Background)));            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(CreateCrossFirebaseSettings());
                //CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
                return false;
            }));
#else
             events.AddAndroid(android => android.OnCreate((activity, bundle) => {
                Firebase.FirebaseApp.InitializeApp(activity);
                CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings());
                //CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
            }));
#endif

            CrossFirebaseCloudMessaging.Current.NotificationTapped += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("NotificationTapped");
                var navigationParameter = new Dictionary<string, object>
                    {
                    { "Notification",  e.Notification}
                    };
            };
            CrossFirebaseCloudMessaging.Current.NotificationReceived += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("NotificationReceived");
            };

        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(
            isAnalyticsEnabled: true,
            isAuthEnabled: true,
            isCloudMessagingEnabled: true,
            isCrashlyticsEnabled: true,
            isDynamicLinksEnabled: true,
            isFirestoreEnabled: true,
            isFunctionsEnabled: true,
            isRemoteConfigEnabled: true,
            isStorageEnabled: true);
    }
}

