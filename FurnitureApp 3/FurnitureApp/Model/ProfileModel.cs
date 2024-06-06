using System;
namespace FurnitureApp.Model
{
	public class ProfileModel
	{
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ThumbnailFileUrl { get; set; }
        public string FileUploadType { get; set; } // refer enum FileUploadType
    }
    public class ImageVM
    {
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }

    }
}

