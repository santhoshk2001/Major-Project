
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ECommerceAppDemo.Web.Services;

namespace ECommerceAppDemo.Web.Controllers
{




    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductsController()
        {
            _httpClient = new HttpClient();
        }

        // Action to display products by category or show default content
        public async Task<ActionResult> Index(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                ViewBag.CategoryName = "Welcome to E-Commerce Site";
                ViewBag.ProductsData = null; // No data to display initially
                var categoriesList = new List<string> { "Television", "Headset", "Refrigerator", "Mobile", "Smartwatch" };
                ViewBag.Categories = categoriesList;
                return View(); // Return the default view with a welcome message
            }

            var apiUrl = $"https://localhost:44368/api/products/bycategory?categoryName={categoryName}";
            var response = await _httpClient.GetStringAsync(apiUrl);

            if (string.IsNullOrEmpty(response))
            {
                ViewBag.CategoryName = "No products found for the specified category.";
                ViewBag.ProductsData = null;
            }
            else
            {
                ViewBag.CategoryName = categoryName;
                ViewBag.ProductsData = response;
            }

            // Pass categories for the header
            var categories = new List<string> { "Television", "Headset", "Refrigerator", "Mobile", "Smartwatch" };
            ViewBag.Categories = categories;

            return View(); // Return the view with the products data for the selected category
        }

        public async Task<ActionResult> Details(int pid)
        {
            var apiUrl = $"https://localhost:44368/api/products/{pid}";
            var response = await _httpClient.GetStringAsync(apiUrl);

            if (string.IsNullOrEmpty(response))
            {
                return HttpNotFound(); // Handle if the product is not found
            }

            // Deserialize the JSON string into a dynamic object
            dynamic productDetails = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

            System.Diagnostics.Debug.WriteLine($"Type of product: {productDetails.GetType().FullName}");
            System.Diagnostics.Debug.WriteLine($"Product: {Newtonsoft.Json.JsonConvert.SerializeObject(productDetails)}");

            ViewBag.ProductDetails = productDetails;
            return View();
        }
        //function():-> add to cart 
    }

}