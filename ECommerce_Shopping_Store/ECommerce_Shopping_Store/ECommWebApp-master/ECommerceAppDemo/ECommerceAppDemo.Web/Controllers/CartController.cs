using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using System.Net.Http;
using ECommerceAppDemo.API.Models;
using System.Threading.Tasks;

namespace ECommerceAppDemo.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly string _apiBaseUrl = "https://localhost:44368/api/cart"; // Replace with your API URL

        // GET: Cart
       
            public ActionResult Index()
            {
                // Call the API to get the cart data
                string apiUrl = "https://localhost:44368/api/cart"; // Replace with your API URL
                string jsonData = new WebClient().DownloadString(apiUrl);

                // Deserialize the JSON data into a list of Cart objects
                List<Cart> cartData = JsonConvert.DeserializeObject<List<Cart>>(jsonData);

                // Pass the cart data to the View
                return View(cartData);
            }


            public ActionResult Invoice()
            {
                // URL of your API
                string apiUrl = "https://localhost:44368/api/cart";
                List<Cart> model = new List<Cart>();

                using (var client = new HttpClient())
                {
                    // Fetch data from the API
                    var responseTask = client.GetAsync(apiUrl);
                    responseTask.Wait();

                    // Read and deserialize the JSON data
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        model = JsonConvert.DeserializeObject<List<Cart>>(readTask.Result);
                    }
                }

                // Return the view as PDF with the model
                return new ViewAsPdf("Invoice", model)
                {
                    FileName = "Invoice.pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Portrait,
                    PageMargins = new Rotativa.Options.Margins(10, 10, 10, 10)
                };
            }
            public ActionResult ThankYou()
            {
                return View();
            }




        [HttpPost] // You can keep it as POST in MVC since the frontend can use POST to trigger this
        public async Task<ActionResult> ClearCart()
        {
            using (var client = new HttpClient())
            {
                // Set the base address to your API's URL
                client.BaseAddress = new Uri("https://localhost:44368/");

                // Send a DELETE request to the API to clear the cart
                HttpResponseMessage response = await client.DeleteAsync("api/cart/clear");

                if (response.IsSuccessStatusCode)
                {
                    // Cart cleared successfully, handle this as needed
                    return RedirectToAction("Index", "Cart"); // Redirect to the cart page or any other page
                }
                else
                {
                    // Handle the error appropriately
                    ModelState.AddModelError("", "Error clearing the cart.");
                    return RedirectToAction("Index", "Cart");
                }
            }
        }

    }
    }


