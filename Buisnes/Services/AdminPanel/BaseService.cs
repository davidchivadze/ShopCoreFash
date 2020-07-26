using Core.Helpers;
using Database.Interfaces;
using Database.Repository;
using Domain.Interfaces;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Services.AdminPanel
{
  public class BaseService:ServiceHelper
    {
        private IUserRepository _userRepository;
        protected IUserRepository UserRepository
        {
            get
            {
                return _userRepository=_userRepository?? new UserRepository(); 
            }
        }
        private IProductRepository _productRepository;
        protected IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository();
            }
        }
    }
}
