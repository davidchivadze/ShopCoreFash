using Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.AdminPanel.Database.Products
{
    public class ProductSizes: BaseModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Categories")]
        public int CategorieID { get; set; }
        public string Description { get; set; }
        public string Description_ka { get; set; }
        public string Descripton_ru { get; set; }
        public virtual Categories Categories { get; set; }

    }
}
