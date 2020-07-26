using System;
using System.Collections.Generic;
using System.Text;

namespace Models.AdminPanel.ViewModels.Products
{
    public class ProductDetails
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        public int ProductSizeID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }


    }
}
