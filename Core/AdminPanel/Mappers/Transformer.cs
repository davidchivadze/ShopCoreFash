using Models.AdminPanel.Database;
using Models.AdminPanel.Database.Accounting;
using Models.AdminPanel.Database.Products;
using Models.AdminPanel.ViewModels.Accounting;
using Models.AdminPanel.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.AdminPanel.Mappers
{
   public static class Transformer
    {
        public static UserViewModel AsViewModel(this User model)
        {
            return new UserViewModel()
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                PIN = model.PIN,
                Address = model.Address,
                IsDeleted = model.IsDeleted,

            };
        }
        public static User AsDatabaseModel(this UserViewModel model)
        {
            return new User()
            {
                //ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                PIN = model.PIN,
                Address = model.Address,
                UserName=model.UserName,
                IsDeleted = model.IsDeleted,
                Password=model.Password,
                

            };
        }
        public static Products AsDatabaseModel(this AddProductModel model)
        {
            var returnModel = new Products()
            {
                Title = model.Title,
                Title_ka = model.Title_ka,
                Title_ru = model.Title_ru,
                ShortDescription_ka = model.ShortDescription_ka,
                ShortDescription_ru = model.ShortDescription_ru,
                ShortDescription = model.ShortDescription,
                 FullDescription=model.FullDescription,
                 FullDescription_ka=model.FullDescription_ka,
                 FullDescription_ru=model.FullDescription_ru,
                 ProductDetails=model.productDetails.Select(m=>new Models.AdminPanel.Database.Products.ProductDetails()
                 {
                      Count=m.Count,
                       Price=m.Price,
                       ProductSizeID=m.ProductSizeID
                 }).ToList(),
                 ProductCategories=model.CategoriesID.Select(m=>new ProductCategories() { CategorieID=m}).ToList(),
                  ProductImages=model.ProductImages.Select(m=>new Models.AdminPanel.Database.Products.ProductImages()
                  {
                       Image=m.Image,
                        Format=m.Format
                  }).ToList()
            };
            return returnModel;

        }
        public static ProductsListItem AsViewModel(this Products model)
        {
            return new ProductsListItem()
            {
                ID = model.ID,
                Title = model.Title,
                Title_ka = model.Title_ka,
                Title_ru = model.Title_ru,
                ShortDescription_ka = model.ShortDescription_ka,
                ShortDescription_ru = model.ShortDescription_ru,
                ShortDescription = model.ShortDescription,
                FullDescription = model.FullDescription,
                FullDescription_ka = model.FullDescription_ka,
                FullDescription_ru = model.FullDescription_ru,
                CategoriesID = model.ProductCategories.Select(m => m.ID).ToArray(),
                productDetails = model.ProductDetails.Select(m => m.AsViewModel()).ToList(),
                ProductImages = model.ProductImages.Select(m => m.AsViewModel()).ToList()
            };
        }
        public static Models.AdminPanel.ViewModels.Products.ProductDetails AsViewModel(this Models.AdminPanel.Database.Products.ProductDetails model)
        {
            return model == null ? null : new Models.AdminPanel.ViewModels.Products.ProductDetails
            {
                ID = model.ID,
                Count = model.Count,
                Price = model.Price,
                ProductID = model.ProductID,
                ProductSizeID = model.ProductSizeID
            };
        }
        public static Models.AdminPanel.ViewModels.Products.ProductImages AsViewModel(this Models.AdminPanel.Database.Products.ProductImages model)
        {
            return model == null ? null : new Models.AdminPanel.ViewModels.Products.ProductImages
            {
                ID = model.ID,
                Format = model.Format,
                Image = model.Image,
                ProductID = model.ProductID
            };
        }
    }
}
