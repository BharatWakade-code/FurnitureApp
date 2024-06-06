using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FurnitureApp.Model
{
	public class ProductByCategory : ObservableObject
    {
	 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ImageSource ProductUrl { get; set; }
        public string ProductDis { get; set; }
        public int ProductTotalPrice { get; set; }
     
        private int _productQuantity;
        public int ProductQuantity
        {
            get { return _productQuantity; }
            set
            {
                if (_productQuantity != value)
                {
                    _productQuantity = value;
                    OnPropertyChanged(nameof(ProductQuantity));
                }
            }
        }


        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public ImageSource ProductImageUrl { get; set; }
        public string CategoryDiscription { get; set; }
        public List<ProductModel> ProductList { get; set; }
    }
}

