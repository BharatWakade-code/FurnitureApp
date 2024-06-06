using System;
using System.Net;
using FurnitureApp.Model;
using Newtonsoft.Json;

namespace FurnitureApp.Services
{
    public class LoginServices
    {
        public LoginServices()
        {
        }

        //public static  async Task<ResponseModel> Post(object data, string uri)
        //{
        //    var client = new HttpClient();
        //    var endpoint = new Uri(uri);

        //    var json = JsonConvert.SerializeObject(data);
        //    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(endpoint, content);
        //    var result = await response.Content.ReadAsStringAsync();
        //    ResponseModel root = JsonConvert.DeserializeObject<ResponseModel>(result);
         
        //    return root;

        //}
        static LoginServices _instance;

        public static LoginServices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoginServices();

                return _instance;
            }
        }

        public static async Task<ResponseModel> Post(object data, string uri)
        {
            var client = new HttpClient();
            var endpoint = new Uri(uri);

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(endpoint, content);
            var result = await response.Content.ReadAsStringAsync();
            ResponseModel root = JsonConvert.DeserializeObject<ResponseModel>(result);
            return root;
        }

        public async Task<GetProfileResponse> GetUserById()
        {
            var result = await RequestProvider.RequestProvider.Instance.GetAsync<ResponseModel>(GlobalUrl.GetUserById);
            if (result.IsSuccess)
            {
                if (result.Response is not null)
                {
                    return JsonConvert.DeserializeObject<GetProfileResponse>(result.Response.ToString());
                }
                else
                {
                    return null;
                }
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Alert!", result.Message, "Ok");
                });
                return null;
            }

        }
    }
}

