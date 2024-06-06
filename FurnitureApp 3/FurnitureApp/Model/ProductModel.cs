using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FurnitureApp.Model
{
    public class ProductModel : ObservableObject
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ImageSource ProductUrl { get; set; }
        public int ProductPrice { get; set; }
        public int ProductMRP { get; set; }
        public int ProductOffers { get; set; }
        public string ProductDis { get; set; }
        public int ProductTotalPrice { get; set; }
        public string ProductDate { get; set; }
        public List<ProductModel> ProductList { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

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

        public class PropertyItem
    {
        public string Header { get; set; }
        public List<PropertyItemDetails> MyPropertyItems { get; set; }  //This name should be same as the the Binding Name or else binding won't work 

    }
    public class PropertyItemDetails
    {
      
        public string CategoryName { get; set; }

        }
    }
   
}

