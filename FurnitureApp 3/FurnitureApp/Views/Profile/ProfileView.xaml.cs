using FurnitureApp.ViewModel.Profile;

namespace FurnitureApp.Views.Profile;

public partial class ProfileView : ContentPage
{
    public ProfileView()
    {
        InitializeComponent();
        BindingContext = new ProfileViewModel(Navigation);
    }

    //void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    //{
    //    try
    //    {
    //        new ImageCropper.Maui.ImageCropper()
    //        {
    //            AspectRatioX = 1,
    //            AspectRatioY = 1,
    //            CropShape = ImageCropper.Maui.ImageCropper.CropShapeType.Rectangle,
    //            Success = async (imageFile) =>
    //            {
    //                await Task.Run(() =>
    //                {
    //                    try
    //                    {
    //                        MainThread.BeginInvokeOnMainThread(async () =>
    //                        {
    //                            var vm = BindingContext as ProfileViewModel;
    //                            var fileBytes = File.ReadAllBytes(imageFile);
    //                            ByteArrayContent byteContent = new ByteArrayContent(fileBytes);
    //                            var bytes = byteContent.ReadAsByteArrayAsync().Result;
    //                            vm.ImageFilePath = imageFile;
    //                            for (int i = 8; bytes.Length > 1000000 && i > 0; i--)
    //                            {
    //                                int size = i * 100;
                                  
    //                                //bytes = await ImageResizer.ResizeImage(bytes);

    //                            }
    //                            vm.ByteInPicture = bytes;
    //                            var getsteram = new MemoryStream(vm.ByteInPicture);
    //                            vm.ProfilePicture = null;
    //                            vm.ProfilePicture = ImageSource.FromStream(() => getsteram);
    //                            //   vm.ProfileBorderColor = GetResourcesValue.TryGetThemeColor("BlueTextColor");
    //                            //Create thumbnails fro small profile picture 
    //                            //var thumbBytes = await ImageResizer.CompressImage(bytes);
    //                            //vm.ByteInThumbPicture = thumbBytes;

    //                        });
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        //ExceptionModel.CrashAnalyticsData(ex);
    //                    }
    //                });
    //            },

    //            Failure = () =>
    //            {
    //                Console.WriteLine("Error capturing an image to crop.");
    //            }
    //        }.Show(this);

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex);
    //    }

    //}



}
