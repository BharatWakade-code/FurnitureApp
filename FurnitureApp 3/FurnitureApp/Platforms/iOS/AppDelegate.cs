using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace FurnitureApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

//[Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
//public void DidReceiveRemoteNotification(UIKit.UIApplication application, NSDictionary userInfo, Action<UIKit.UIBackgroundFetchResult> completionHandler)
//{
//    PushManager.Instance.ReceivedRemoteNotification(userInfo);
//}

//[Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
//public void RegisteredForRemoteNotifications(UIKit.UIApplication application, NSData deviceToken)
//{
//    PushManager.Instance.RegisteredForRemoteNotifications(deviceToken);
//}

//[Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
//public void FailedToRegisterForRemoteNotifications(UIKit.UIApplication application, NSError error)
//{
//    PushManager.Instance.FailedToRegisterForRemoteNotifications(error);
//}