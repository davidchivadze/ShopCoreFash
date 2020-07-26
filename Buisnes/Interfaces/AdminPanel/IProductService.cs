using Core.Helpers;
using Models.AdminPanel.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisnes.Interfaces.AdminPanel
{
    public interface IProductService
    {
        IResponse<bool> AddProduct(AddProductModel model);
        IResponse<GetAllProductResponse> GetAllProduct(GetAllProductRequest model);
    }
}
