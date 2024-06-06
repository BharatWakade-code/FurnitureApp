using System;
using FurnitureApp.Model;

namespace FurnitureApp.Model
{
	public class CategoryModel
	{
        public int  Id { get; set; }
        public string CategoryName { get; set; }
        public ImageSource ProductImageUrl { get; set; } 
        public string Price { get; set; }
        public List<ProductModel> ProductList { get; set; }
    }
}


