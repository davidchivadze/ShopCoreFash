using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.AdminPanel.Database.Products
{
    public class ProductCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Categories")]
        public int CategorieID { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }
        public virtual Categories Categories {get;set;}
        public virtual Products Products { get; set; }
    }
}
