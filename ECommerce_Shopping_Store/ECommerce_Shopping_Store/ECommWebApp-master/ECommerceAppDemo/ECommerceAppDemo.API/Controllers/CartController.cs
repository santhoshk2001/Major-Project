using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;
using ECommerceAppDemo.API.Services;
using System.Web.Http.Cors;
using System;

namespace ECommerceAppDemo.API.Controllers
{

    [EnableCors(origins: "https://localhost:44347", headers:"*",methods:"*")]
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private readonly CartService _cartService;

        public CartController()
        {
            _cartService = new CartService(new CartRepository(new ECommerceDbContext()), new OrderDetailsRepository(new ECommerceDbContext()));
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCartById(int id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        // GET api/cart
        [HttpGet]
        public IHttpActionResult GetAllCarts()
        {
            var carts = _cartService.GetAllCarts();
            return Ok(carts);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddToCart(Cart request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _cartService.AddToCartAsync(request.UserId, request.PId);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCart = _cartService.GetCartById(id);
            if (existingCart == null)
            {
                return NotFound();
            }
            cart.CartId = id;
            _cartService.UpdateCart(cart);
            return Ok(cart);
        }

        // DELETE api/cart/{id}
        /*[HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCartById(int id)
        {
            _cartService.DeleteCartById(id);
            return StatusCode(HttpStatusCode.NoContent);
        }*/

        // DELETE api/cart/clear
        [HttpDelete]
        [Route("clear")]
        public IHttpActionResult ClearAllCarts()
        {
            _cartService.ClearAllCarts();
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpGet]
        [Route("process")]
        public IHttpActionResult CopyCartToOrderDetails()
        {
            _cartService.CopyCartToOrderDetails();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult TestCors()
        {
            return Ok("Cors is worling");
        }

        [HttpPut]
        [Route("api/cart/update")]
        public IHttpActionResult UpdateCart(int cartId, int quantity)
        {
            try
            {
                _cartService.UpdateCart(cartId, quantity);
                return Ok("Cart updated successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



    }
}
