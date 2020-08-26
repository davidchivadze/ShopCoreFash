using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buisnes.Interfaces.AdminPanel;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.AdminPanel.ViewModels.Products;
using Models.AdminPanel.ViewModels.Shared;

namespace ShopCore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("AddProduct")]
        public IResponse<bool> AddProduct([FromBody]AddProductModel model)
        {
            return _productService.AddProduct(model);            
        }
        [HttpGet("GetAllProducts")]
        public IResponse<GetAllProductResponse> GetAllProducts(GetAllProductRequest model)
        {
            return _productService.GetAllProduct(model);
        }
    }
}