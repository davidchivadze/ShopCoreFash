using Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.AdminPanel.Database.Products
{
    public class Categories: BaseModel
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }
        public string Description_ka { get; set; }
        public string Descripton_ru { get; set; }

    }
}
