using Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.AdminPanel.Database.Products
{
    public class Products:BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title_ka { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title_ru { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ShortDescription { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ShortDescription_ka { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ShortDescription_ru { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string FullDescription { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string FullDescription_ka { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string FullDescription_ru { get; set; }


        public virtual List<ProductDetails> ProductDetails  {get;set;}
        public virtual List<ProductCategories> ProductCategories { get; set; }
        public virtual List<ProductImages> ProductImages { get; set; }

    }
}
