using Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.AdminPanel.Database.Products
{
    public class ProductDetails: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Products")]
        public int ProductID { get; set; }
        [ForeignKey("ProductSize")]
        public int ProductSizeID { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public decimal Price { get; set; }
        public int Count { get; set; }

        public virtual ProductSizes ProductSize { get; set; }
        public virtual Products Products { get; set; }
    }
}
