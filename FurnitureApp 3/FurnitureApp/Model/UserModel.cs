using System;
using Newtonsoft.Json;


namespace FurnitureApp.Model
{
    public class ProfileImage
    {
        [JsonProperty("imageUrl")]
        public object ImageUrl { get; set; }

        [JsonProperty("thumbnailUrl")]
        public object ThumbnailUrl { get; set; }
    }

    public class LoginResponseModel
    {
        [JsonProperty("token")]
        public Token Token { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class ResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("response")]
        public object Response { get; set; }

        [JsonProperty("errors")]
        public object Errors { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class Token
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("tokenType")]
        public string TokenType { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }
    }
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public object PhoneNumber { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("profileImage")]
        public ProfileImage ProfileImage { get; set; }

        [JsonProperty("profileImageFileName")]
        public object ProfileImageFileName { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("industryId")]
        public int IndustryId { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("ageRangeId")]
        public int AgeRangeId { get; set; }

        [JsonProperty("ageRange")]
        public string AgeRange { get; set; }

        [JsonProperty("userStatusId")]
        public int UserStatusId { get; set; }

        [JsonProperty("userStatus")]
        public string UserStatus { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("deviceToken")]
        public string DeviceToken { get; set; }

        [JsonProperty("appThemeId")]
        public int AppThemeId { get; set; }

        [JsonProperty("appThemeName")]
        public string AppThemeName { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("lastActiveAt")]
        public DateTime LastActiveAt { get; set; }
    }

    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => (FirstName + " " + LastName).Trim();

        //public string ProfilePictureUrl { get; set; }
        //public string ProfilePictureThumbUrl { get; set; }
        public string ProfileImageFileName { get; set; }
        public ImageVM ProfileImage { get; set; }
        public string Occupation { get; set; }

        public int IndustryId { get; set; }
        public string Industry { get; set; }

        public int AgeRangeId { get; set; }
        public string AgeRange { get; set; }

        public int UserStatusId { get; set; }
        public string UserStatus { get; set; }

        public string TimeZone { get; set; }
        public string DeviceToken { get; set; }
        public int AppThemeId { get; set; }
        public string AppThemeName { get; set; }

    }
    

}

