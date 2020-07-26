using Buisnes.Interfaces.AdminPanel;
using Buisness.Services.AdminPanel;
using Core.AdminPanel.Mappers;
using Core.Helpers;
using Models.AdminPanel.Database.Products;
using Models.AdminPanel.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buisnes.Services.AdminPanel
{
    public class ProductService : BaseService, IProductService
    {
        public IResponse<bool> AddProduct(AddProductModel model)
        {
            try
            {
                var result = ProductRepository.AddProduct(Transformer.AsDatabaseModel(model));
                return Ok<bool>(true);
            }
            catch (Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }
        public IResponse<GetAllProductResponse> GetAllProduct(GetAllProductRequest model)
        {
            try
            {
                var result = ProductRepository.GetAllProducts(model.Skip ?? 0, model.Take ?? 10)
                    .Select(m=>m.AsViewModel()).ToList();
                return Ok<GetAllProductResponse>(new GetAllProductResponse() { result=result });

            }catch(Exception ex)
            {
                return Fail<GetAllProductResponse>(ex.Message);
            }
        }
    }
}
