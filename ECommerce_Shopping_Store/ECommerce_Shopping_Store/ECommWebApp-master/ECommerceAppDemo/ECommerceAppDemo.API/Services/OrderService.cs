using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceAppDemo.API.Repositories;

namespace ECommerceAppDemo.API.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(int productId, int quantity)
        {
            _orderRepository.CreateOrder(productId, quantity);
        }
    }
}