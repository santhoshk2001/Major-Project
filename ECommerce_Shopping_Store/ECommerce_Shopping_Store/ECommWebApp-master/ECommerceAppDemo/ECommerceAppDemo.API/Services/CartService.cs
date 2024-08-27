using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceAppDemo.API.Services
{
    public class CartService
    {
        private readonly CartRepository _cartRepository;
        private readonly OrderDetailsRepository _orderDetailsRepository;

        public CartService(CartRepository cartRepository, OrderDetailsRepository orderDetailsRepository)
        {
            _cartRepository = cartRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public Cart GetCartById(int cartId)
        {
            return _cartRepository.GetCartById(cartId);
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _cartRepository.GetAllCarts();
        }

        public async Task AddToCartAsync(int userId, int pId)
        {
            await _cartRepository.AddToCartAsync(userId, pId);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        }


        public void ClearAllCarts()
        {
            _cartRepository.ClearAllCarts();
        }

        public void CopyCartToOrderDetails()
        {
            _cartRepository.CopyCartToOrderDetails();
        }
        public void UpdateCart(int cartId, int quantity)
        {
            _cartRepository.UpdateCart(cartId, quantity);
        }
    }
}
