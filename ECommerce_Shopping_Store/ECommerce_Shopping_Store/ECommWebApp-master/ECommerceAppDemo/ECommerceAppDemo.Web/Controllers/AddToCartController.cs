using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

public class AddToCartController : Controller
{
    [HttpPost]
    public async Task<ActionResult> Add(int productId)
    {
        var userId = Session["UserId"] as int?;
        if (!userId.HasValue)
        {
            return Json(new { success = false, message = "User not logged in" });
        }

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:44368/");
            var content = new StringContent(JsonConvert.SerializeObject(new { UserId = userId.Value, PId = productId }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/cart/add", content);

            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Product added to cart successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Error adding product to cart" });
            }
        }
    }
}

