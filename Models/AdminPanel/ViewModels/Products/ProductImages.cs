using System;
using System.Collections.Generic;
using System.Text;

namespace Models.AdminPanel.ViewModels.Products
{
    public class ProductImages
    {
   
        public int ID { get; set; }
        public int ProductID { get; set; }
        public byte[] Image { get; set; }
        public string Format { get; set; }

    }
}
