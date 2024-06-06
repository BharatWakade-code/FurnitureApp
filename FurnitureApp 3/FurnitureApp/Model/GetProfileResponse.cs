using System;
namespace FurnitureApp.Model
{
    public class GetProfileResponse
    {
        public GetProfileResponse()
        {
            User = new UserModel();
        }
        public UserModel User { get; set; }
    }
}

