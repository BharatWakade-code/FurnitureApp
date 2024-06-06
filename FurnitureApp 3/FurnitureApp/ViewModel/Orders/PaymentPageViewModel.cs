using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FurnitureApp.Views.Home;
using Plugin.Firebase.CloudMessaging;
using Plugin.LocalNotification;

namespace FurnitureApp.ViewModel.Orders
{
    public partial class PaymentPageViewModel : ObservableObject
    {
        #region Fields  
        private INavigation _navigation;
        private string _deviceToken;
        #endregion

        #region ctr
        public PaymentPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            //  LocalNotificationCenter.Current.NotificationActionTapped+=Current_NotificationActionTapped;

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
        private async Task SuccesPayment()
        {
            try
            {

                //await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
                //var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
                //Console.WriteLine($"FCM token: {token}");
                //await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
                //var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
                //Console.WriteLine($"FCM token : {token}");

                await App.Current.MainPage.DisplayAlert("", "Your payment has been done successfully ", "OK");
                var notificationId = 10;
                var title = "🎉 Your Order is Shipped 📦";
                var description = "Great news! Your order has been shipped and is on its way to you.";
                var badgeNumber = 41;
                var notifyTime = DateTime.Now.AddSeconds(1);
                var notifyRepeatInterval = TimeSpan.FromDays(1);

                var request = new NotificationRequest
                {
                    NotificationId = notificationId,
                    Title = title,
                    Description = description,
                    BadgeNumber = badgeNumber,

                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = notifyTime,
                        NotifyRepeatInterval = notifyRepeatInterval,
                    },
                };
                await LocalNotificationCenter.Current.Show(request);
                await _navigation.PushAsync(new HomePageView());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
}

[RelayCommand]
private async Task VAO()
{
    try
    {
        await Launcher.OpenAsync(new Uri("https://www.mysmartprice.com/gear/flipkart-upcoming-sale/"));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}


[RelayCommand]
private async Task TC()
{
    try
    {
        await Launcher.OpenAsync(new Uri("https://www.mysmartprice.com/terms/"));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}
        #endregion

        #region Private Methods
        //private async void Current_NotificationActionTapped( Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
        //{
        //   if(e.IsTapped)
        //    {
        //        await _navigation.PushAsync(new OrderSummaryView());
        //    }
        //}

        #endregion
    }
}

