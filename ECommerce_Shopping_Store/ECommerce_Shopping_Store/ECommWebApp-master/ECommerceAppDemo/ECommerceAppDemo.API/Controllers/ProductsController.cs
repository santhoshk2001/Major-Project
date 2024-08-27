using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Repositories;
using ECommerceAppDemo.API.Services;

namespace ECommerceAppDemo.API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
   
            _productService = productService;
        }

        [HttpGet]
        [Route("api/products/bycategory")]
        public IHttpActionResult GetProductsByCategory(string categoryName)
        {
            var products = _productService.GetProductsByCategory(categoryName);

            if (products == null || !products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("api/products/{pid}")]
        public IHttpActionResult GetProductById(int pid)
        {
            using (var context = new ECommerceDbContext())
            {
                var product = context.Products.FirstOrDefault(p => p.PID == pid);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
        }

    }
}
