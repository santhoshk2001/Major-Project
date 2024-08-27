// File: Controllers/OrderDetailsController.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;
using ECommerceAppDemo.API.Services;

namespace ECommerceAppDemo.API.Controllers
{
    [EnableCors(origins: "https://localhost:44347", headers: "*", methods: "*")]
    [RoutePrefix("api/orderdetails")]
    public class OrderDetailsController : ApiController
    {
        private readonly OrderDetailsService _orderDetailsService;

        public OrderDetailsController()
        {
            _orderDetailsService = new OrderDetailsService(new OrderDetailsRepository(new ECommerceDbContext()));
        }

        // GET api/orderdetails
        [HttpGet]
        public IHttpActionResult GetAllOrderDetails()
        {
            var orderDetails = _orderDetailsService.GetAllOrderDetails();
            return Ok(orderDetails);
        }

        // GET api/orderdetails/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetOrderDetailsById(int id)
        {
            var orderDetails = _orderDetailsService.GetOrderDetailsById(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }

        // POST api/orderdetails
        [HttpPost]
        public IHttpActionResult AddOrderDetails(OrderDetails orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _orderDetailsService.AddOrderDetails(orderDetails);
            return CreatedAtRoute("DefaultApi", new { id = orderDetails.OrderDetailId }, orderDetails);
        }
    }
}
