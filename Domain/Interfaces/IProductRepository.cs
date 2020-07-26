using Models.AdminPanel.Database.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        bool AddProduct(Products model);
        IEnumerable<Products> GetAllProducts(int skip, int take);
    }
}
