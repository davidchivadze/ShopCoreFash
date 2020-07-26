using Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.AdminPanel.Database.Products
{
    public class ProductImages:BaseModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public byte[] Image { get; set; }
        public string Format { get; set; }
        
        public virtual Products Product { get; set; }
    }
}
