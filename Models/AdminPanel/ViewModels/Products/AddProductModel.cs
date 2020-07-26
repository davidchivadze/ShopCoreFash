using System;
using System.Collections.Generic;
using System.Text;

namespace Models.AdminPanel.ViewModels.Products
{
    public class AddProductModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Title_ka { get; set; }

        public string Title_ru { get; set; }

        public string ShortDescription { get; set; }

        public string ShortDescription_ka { get; set; }

        public string ShortDescription_ru { get; set; }

        public string FullDescription { get; set; }

        public string FullDescription_ka { get; set; }

        public string FullDescription_ru { get; set; }
        public List<ProductImages> ProductImages { get; set; }
        public List<ProductDetails> productDetails { get; set; }
        public int[] CategoriesID { get; set; }
    }

}
