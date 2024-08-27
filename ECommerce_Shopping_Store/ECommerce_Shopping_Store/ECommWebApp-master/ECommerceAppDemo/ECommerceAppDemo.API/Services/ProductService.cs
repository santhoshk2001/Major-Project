using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;

namespace ECommerceAppDemo.API.Services
{
   
        public class ProductService
        {
            private readonly ProductRepository _productRepository;

            public ProductService(ProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public IEnumerable<object> GetProductsByCategory(string categoryName)
            {
                return _productRepository.GetProductsByCategory(categoryName);
            }
        }

    
}