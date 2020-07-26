using Database.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.AdminPanel.Database.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public class ProductRepository : BaseRepository<Products>, IProductRepository
    {
        public bool AddProduct(Products model)
        {
            try { 
            Database.Products.Add(model);
            Database.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Products> GetAllProducts(int skip, int take)
        {
            try
            {
              var result= Database.Products.Include(m => m.ProductDetails).ThenInclude(m=>m.ProductSize).Include(m => m.ProductImages).Include(m => m.ProductCategories).OrderByDescending(m=>m.ID).Skip(skip).Take(take);
                return result;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public Products GetEditProduct(int productID)
        //{

        //}
    }
}
