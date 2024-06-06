using System;
using Newtonsoft.Json;

namespace FurnitureApp.Model
{
    public class ApiModel
    {
        public class Login
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class LoginRequestModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public int PlatformId { get; set; }
            public string TimeZone { get; set; }
            public string DeviceToken { get; set; }
            public int AppThemeId { get; set; }
            public string DeviceId { get; set; }
        }


    }
}