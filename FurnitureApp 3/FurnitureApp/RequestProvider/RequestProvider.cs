using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using FurnitureApp.Model;
using FurnitureApp.Services;

namespace FurnitureApp.RequestProvider
{
	
    public class RequestProvider
    {

        #region Fields
        private readonly Lazy<HttpClient> _httpClient =
           new(() =>
           {
               var httpClient = new HttpClient();
               httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               return httpClient;
           },
               LazyThreadSafetyMode.ExecutionAndPublication);
        static RequestProvider _instance;
        #endregion

        #region ctr & Instance
        public RequestProvider()
        {
        }
        public static RequestProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RequestProvider();

                return _instance;
            }
        }
        #endregion

        #region Private Methods
        public async Task<TResult> PostAsync<TResult>(string uri, object data, string token = "", string header = "")
        {
            HttpClient httpClient = GetOrCreateHttpClient(SettingServices.Instance.AccessToken);

            System.Diagnostics.Debug.WriteLine(SettingServices.Instance.AccessToken);
            System.Diagnostics.Debug.WriteLine(JsonSerializer.Serialize(data));
            System.Diagnostics.Debug.WriteLine(GlobalUrl.BaseUrl + uri);
            var content = new StringContent(JsonSerializer.Serialize(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(GlobalUrl.BaseUrl + uri, content).ConfigureAwait(false);

            await RequestProvider.HandleResponse(response).ConfigureAwait(false);
            TResult result = await response.Content.ReadFromJsonAsync<TResult>();
            System.Diagnostics.Debug.WriteLine("Response Received " + uri);
            return result;
        }


        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            HttpClient httpClient = GetOrCreateHttpClient(SettingServices.Instance.AccessToken);
            HttpResponseMessage response = await httpClient.GetAsync(GlobalUrl.BaseUrl + uri).ConfigureAwait(false);
            System.Diagnostics.Debug.WriteLine(SettingServices.Instance.AccessToken);
            System.Diagnostics.Debug.WriteLine(GlobalUrl.BaseUrl + uri);
            await RequestProvider.HandleResponse(response).ConfigureAwait(false);

            TResult result = await response.Content.ReadFromJsonAsync<TResult>();
            System.Diagnostics.Debug.WriteLine("Response Received " + uri);
            return result;
        }
        private HttpClient GetOrCreateHttpClient(string token = "")
        {
            var httpClient = _httpClient.Value;

            httpClient.DefaultRequestHeaders.Authorization =
                !string.IsNullOrEmpty(token)
                    ? new AuthenticationHeaderValue("Bearer", token)
                    : null;

            return httpClient;
        }

        private static async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        await App.Current.MainPage.DisplayAlert("Alert!", "There seems to be problem with the server. Please try again after some time.", "Ok");
                        return;
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        await App.Current.MainPage.DisplayAlert("Alert!", "API Not Found!", "Ok");
                        return;
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        if (App.Current.MainPage != null)
                        {
                            App.Current.MainPage = new NavigationPage(new Views.Account.LoginView());
                        }
                        else
                        {
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {

                    }
                    else if (response.StatusCode == HttpStatusCode.RequestEntityTooLarge)
                    {
                        await App.Current.MainPage.DisplayAlert("Alert!", response.ReasonPhrase, "Ok");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Alert!", "Something went wrong", "Ok");
                    }
                });
            }
        }
        #endregion
    }

}


